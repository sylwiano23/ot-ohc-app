using Application.Surveys.Commands.AddSurvey;
using Application.Surveys.Commands.DeleteSurvey;
using Application.Surveys.Commands.UpdateSurvey;
using Application.Surveys.Queries.GetSurvey;
using Application.Surveys.Queries.GetSurveysList;
using Application.Surveys.Queries.Models;
using Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Attributes;

namespace WebAPI.Controllers
{
    [Authorized]
    public class SurveysController : BaseController
    {
        [Authorized(UserRole.Administrator, UserRole.User)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SurveysListVm>> Get([FromQuery] FactorTypeEnum factorType, [FromQuery] string sort, [FromQuery] string sortDirection)
        {
            return await Mediator.Send(new GetSurveysListQuery { FactorType = factorType, SortOrder = sortDirection, PropertyName = sort });
        }

        [HttpGet("getById/{id}")]
        [Authorized(UserRole.Administrator, UserRole.User)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SurveyDto>> Get(int id)
        {
            return await Mediator.Send(new GetSurveyQuery { Id = id });
        }

        [HttpPost]
        [Authorized(UserRole.Administrator)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add([FromBody] AddSurveyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Authorized(UserRole.Administrator)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] UpdateSurveyCommand  command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorized(UserRole.Administrator)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSurveyCommand { Id = id }));
        }
    }
}
