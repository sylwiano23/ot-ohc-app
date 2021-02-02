using Application.Surveys.Queries.Models;
using Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Application.Surveys.Queries.GetSurveysList
{
    public class GetSurveysListQueryHandler : IRequestHandler<GetSurveysListQuery, SurveysListVm>
    {
        private readonly IOhcDbContext _context;

        public GetSurveysListQueryHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<SurveysListVm> Handle(GetSurveysListQuery request, CancellationToken cancellationToken)
        {
            var surveys = await _context.Surveys
                .Where(s => s.FactorType == request.FactorType)
                .OrderBy(request.PropertyName + " " + request.SortOrder) 
                .ToListAsync();

            var result = new SurveysListVm();

            foreach (var survey in surveys)
            {
                var surveyDto = new SurveyDto()
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

                result.Surveys.Add(surveyDto);
            }

            return result;
        }
    }
}
