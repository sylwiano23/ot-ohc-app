using Application.Surveys.Queries.Models;
using MediatR;

namespace Application.Surveys.Queries.GetSurvey
{
    public class GetSurveyQuery : IRequest<SurveyDto>
    {
        public int Id { get; set; }
    }
}
