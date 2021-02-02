using Application.Factors.Commands;
using Application.Factors.Queries.GetFactorById;
using Application.Factors.Queries.GetFactorsList;
using Application.Factors.Queries.GetFactorsListByType;
using Application.Factors.Queries.Models;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Attributes;

namespace WebAPI.Controllers
{
    [Authorized]
    public class FactorsController : BaseController
    {
        [HttpGet("getAll")]
        [Authorized(UserRole.Administrator, UserRole.User)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FactorsListVm>> Get()
        {
            return Ok(await Mediator.Send(new GetFactorsListQuery()));
        }

        [HttpGet()]
        [Authorized(UserRole.Administrator, UserRole.User)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FactorsListVm>> Get([FromQuery] FactorTypeEnum factorType)
        {
            return Ok(await Mediator.Send(new GetFactorsListByTypeQuery { FactorType = factorType }));
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FactorDto>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFactorByIdQuery { Id = id }));
        }

        [HttpPost]
        [Authorized(UserRole.Administrator)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add([FromBody] AddFactorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPut]
        [Authorized(UserRole.Administrator)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] UpdateFactorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorized(UserRole.Administrator)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteFactorCommand { Id = id });
            return NoContent();
        }
    }
}
