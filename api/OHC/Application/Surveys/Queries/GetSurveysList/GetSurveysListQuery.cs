using Application.Surveys.Queries.Models;
using Common.Extensions;
using Domain.Enums;
using MediatR;

namespace Application.Surveys.Queries.GetSurveysList
{
    public class GetSurveysListQuery : SortedQuery, IRequest<SurveysListVm>
    {
        public FactorTypeEnum FactorType { get; set; }
    }
}
