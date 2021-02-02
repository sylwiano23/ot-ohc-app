using Application.Auth.Queries.Models;
using Application.Auth.Queries.SignInUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthTokenDto>> SignIn([FromBody] SignInUserQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
