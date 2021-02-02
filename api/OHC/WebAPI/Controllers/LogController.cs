using Application.System.Commands.LogErrors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User, Administrator")]
    public class LogController : BaseController
    {
        [HttpPost]       
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> LogError([FromBody] LogErrorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
