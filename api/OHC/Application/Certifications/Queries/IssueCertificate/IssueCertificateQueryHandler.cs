using Application.Certifications.Queries.IssueCertificate;
using Common.Exceptions;
using Common.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RazorLight;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Certifications.IssueCertificate
{
    public class IssueCertificateQueryHandler : IRequestHandler<IssueCertificateQuery, IssueCertificateQueryVm>
    {
        private readonly IOhcDbContext _context;
        private readonly IRazorLightEngine _razorEngine;
        private readonly IConverter _pdfConverter;

        public IssueCertificateQueryHandler(IOhcDbContext context, IRazorLightEngine razorEngine, IConverter pdfConverter)
        {
            _context = context;
            _razorEngine = razorEngine;
            _pdfConverter = pdfConverter;
        }

        public async Task<IssueCertificateQueryVm> Handle(IssueCertificateQuery request, CancellationToken cancellationToken)
        {
            var position = await _context.Positions
                                .SingleOrDefaultAsync(c => c.Id == request.PositionId, cancellationToken);

            if (position == null)
            {
                throw new NotFoundException(nameof(Position), request.PositionId);
            }

            var factors = _context.FactorPositions
                .Where(p => p.PositionId == position.Id)
                .Select(s => s.Factor).ToList();

            var groupedFactors = factors
                .GroupBy(k => k.FactorType, v => v.Name)
                .ToDictionary(k => k.Key, v => v.ToList());

            var model = new CertificateDto
            {
                Name = request.Name,
                Surname = request.Surname,
                PeselNumber = request.PeselNumber,
                SexType = (SexTypeEnum)Enum.Parse(typeof(SexTypeEnum), request.SexType),
                PositionName = request.PositionName,
                CertificateType = (CertificateTypeEnum)Enum.Parse(typeof(CertificateTypeEnum), request.CertificateType),
                Factors = groupedFactors,
                HouseNumber = request.HouseNumber,
                City = request.City,
                Street = request.Street,
                Description = position.Description
            };

            string template = await GetCertificateTemplate(model);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                DocumentTitle = $"Skierowanie_na_badanie_lekarskie_{model.Name}_{model.Surname}_{DateTime.Now.ToShortDateString()}",
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = template,
                WebSettings = { DefaultEncoding = "utf-8" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var vm = new IssueCertificateQueryVm
            {
                File = _pdfConverter.Convert(pdf)
            };

            return vm;
        }

        private async Task<string> GetCertificateTemplate(CertificateDto certificateDto)
        {
            string templatePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"Templates/HTMLTemplate.cshtml");
            string template = await _razorEngine.CompileRenderAsync(templatePath, certificateDto);

            return template;
        }
    }
}
