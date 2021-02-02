using Application.Positions.Commands;
using Application.Positions.Queries.GetPosition;
using Application.Positions.Queries.GetPositionsList;
using Application.Positions.Queries.Models;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Attributes;

namespace WebAPI.Controllers
{
    [Authorized]
    public class PositionsController : BaseController
    {
        [HttpGet]
        [Authorized(UserRole.Administrator, UserRole.User)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PositionsListVm>> Get()
        {
            return await Mediator.Send(new GetPositionsListQuery());
        }

        [HttpGet("{id}")]
        [Authorized(UserRole.Administrator, UserRole.User)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PositionVm>> Get(int id)
        {
            return await Mediator.Send(new GetPositionQuery { Id = id });
        }
    
        [HttpPost]
        [Authorized(UserRole.Administrator)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add([FromBody] AddPositionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Authorized(UserRole.Administrator)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] UpdatePositionCommand command)
        {          
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorized(UserRole.Administrator)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePositionCommand { Id = id });
            return NoContent();
        }
    }
}
