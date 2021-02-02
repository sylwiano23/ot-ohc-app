using Application.Auth.Queries.Models;
using MediatR;

namespace Application.Auth.Queries.SignInUser
{
    public class SignInUserQuery : IRequest<AuthTokenDto>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
