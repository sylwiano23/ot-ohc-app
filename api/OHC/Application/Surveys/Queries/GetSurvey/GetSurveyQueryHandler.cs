using Application.Surveys.Queries.Models;
using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities.Survey;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Surveys.Queries.GetSurvey
{
    public class GetSurveyQueryHandler : IRequestHandler<GetSurveyQuery, SurveyDto>
    {
        private readonly IOhcDbContext _context;

        public GetSurveyQueryHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<SurveyDto> Handle(GetSurveyQuery request, CancellationToken cancellationToken)
        {
            var survey = await _context.Surveys
                .SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (survey == null)
            {
                throw new NotFoundException(nameof(Survey), request.Id);
            }

            var result = new SurveyDto()
            {
                Date = survey.Date,
                FactorName = survey.FactorName,
                FactorType = survey.FactorType.ToString(),
                Id = survey.Id,
                Interpretation = survey.Interpretation,
                Performer = survey.Performer,
                Position = survey.Position,
                Place = survey.Place,
                Result = survey.Result,
                NextSurveyDate = survey.NextSurveyDate,
                IsSurveySuspend = survey.IsSurveySuspend,
                MarkedParameter = survey.MarkedParameter,
                IdentificationSurveyMethod = survey.IdentificationSurveyMethod,
                DescriptionSurveyMethod = survey.DescriptionSurveyMethod,
                DengerousZoneE = survey.DengerousZoneE,
                DengerousZoneH = survey.DengerousZoneH,
                IntermediateZoneE = survey.IntermediateZoneE,
                IntermediateZoneH = survey.IntermediateZoneH,
                RiskZoneE = survey.RiskZoneE,
                RiskZoneH = survey.RiskZoneH,
                Exposure = survey.Exposure,
                Device = survey.Device,
                DeviceKind = survey.DeviceKind,
                NormValue = survey.NormValue
            };

            return result;
        }
    }
}
