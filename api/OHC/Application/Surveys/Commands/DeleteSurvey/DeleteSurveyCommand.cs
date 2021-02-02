using MediatR;
using System.Collections.Generic;
using System.Text;

namespace Application.Surveys.Commands.DeleteSurvey
{
    public class DeleteSurveyCommand : IRequest
    {
        public int Id { get; set; }
    }
}
