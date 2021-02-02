using Application.Certifications.Queries.IssueCertificate;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Attributes;

namespace WebAPI.Controllers
{
    [Authorized(UserRole.Administrator, UserRole.User)]
    public class CertificationsController : BaseController
    {
        [HttpPost]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IssueCertificateQueryVm>> Issue([FromBody] IssueCertificateQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
