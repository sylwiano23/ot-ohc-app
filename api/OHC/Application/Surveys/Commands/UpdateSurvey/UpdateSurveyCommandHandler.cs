using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities.Survey;
using Domain.Entities.Survey.Helpers;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Surveys.Commands.UpdateSurvey
{
    public class UpdateSurveyCommandHandler : IRequestHandler<UpdateSurveyCommand, int>
    {
        private readonly IOhcDbContext _context;

        public UpdateSurveyCommandHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {
            var survey = await _context.Surveys
                .SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
            
            if (survey == null)
            {
                throw new NotFoundException(nameof(Survey), request.Id);
            }

            var surveyProperties = new SurveyProperties();
            var factorType = (FactorTypeEnum)Enum.Parse(typeof(FactorTypeEnum), request.FactorType);

            surveyProperties.FactorType = factorType;
            surveyProperties.FactorName = request.FactorName;
            surveyProperties.Date = request.Date;
            surveyProperties.Interpretation = request.Interpretation;
            surveyProperties.Performer = request.Performer;
            surveyProperties.Place = request.Place;
            surveyProperties.Position = request.Position;
            surveyProperties.Result = request.Result;
            surveyProperties.NextSurveyDate = request.NextSurveyDate;
            surveyProperties.IsSurveySuspend = request.IsSurveySuspend;
            
            switch (factorType)
            {
                case FactorTypeEnum.Biological:
                    surveyProperties.IdentificationSurveyMethod = request.IdentificationSurveyMethod;
                    surveyProperties.DescriptionSurveyMethod = request.DescriptionSurveyMethod;
                    surveyProperties.MarkedParameter = request.MarkedParameter;
                    break;

                case FactorTypeEnum.Dust:
                    surveyProperties.NormValue = request.NormValue;
                    break;

                case FactorTypeEnum.Physical:
                    surveyProperties.NormValue = request.NormValue;
                    break;

                case FactorTypeEnum.ElectromagneticField:
                    surveyProperties.Exposure = request.Exposure;
                    surveyProperties.Device = request.Device;
                    surveyProperties.IntermediateZoneE = request.IntermediateZoneE;
                    surveyProperties.IntermediateZoneH = request.IntermediateZoneH;
                    surveyProperties.DengerousZoneE = request.DengerousZoneE;
                    surveyProperties.DengerousZoneH = request.DengerousZoneH;
                    surveyProperties.RiskZoneE = request.RiskZoneE;
                    surveyProperties.RiskZoneH = request.RiskZoneH;
                    surveyProperties.DeviceKind = request.DeviceKind;
                    break;

                case FactorTypeEnum.Lighting:
                    surveyProperties.Device = request.Device;
                    surveyProperties.DeviceKind = request.DeviceKind;
                    break;
            }

            survey.ChangeDetails(surveyProperties);

            await _context.SaveChangesAsync(cancellationToken);

            return survey.Id;
        }
    }
}
