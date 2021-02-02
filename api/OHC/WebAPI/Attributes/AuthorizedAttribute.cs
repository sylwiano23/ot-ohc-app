using Common.Extensions;
using Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace WebAPI.Attributes
{
    public class AuthorizedAttribute : AuthorizeAttribute
    {
        public AuthorizedAttribute(params UserRole[] roles) : base()
        {
            Roles = roles.Any() ? string.Join(",", roles.Select(x => x.GetName())) : null;
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
