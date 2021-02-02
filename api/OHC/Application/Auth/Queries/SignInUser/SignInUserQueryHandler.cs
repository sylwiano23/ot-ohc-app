using Application.Auth.Queries.Models;
using Common.Exceptions;
using Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth.Queries.SignInUser
{
    public class SignInUserQueryHandler : IRequestHandler<SignInUserQuery, AuthTokenDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserManager _userManager;

        public SignInUserQueryHandler(IConfiguration configuration, IUserManager userManager)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthTokenDto> Handle(SignInUserQuery request, CancellationToken cancellationToken)
        {
            var isValidUser = await _userManager.ValidateUser(request.Login, request.Password);
            if (!isValidUser)
            {
                throw new BadRequestException("Incorrect user name or password");
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, request.Login),
            };

            var userRoles = await _userManager.GetUserRoles(request.Login);
            foreach (var role in userRoles)
            {
                claims.Add(new Claim("role", role));
            }

            var secretBytes = Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt").GetSection("Secret").Value);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                _configuration.GetSection("Jwt").GetSection("Issuer").Value,
                _configuration.GetSection("Jwt").GetSection("Audience").Value,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(168),
                signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            var result = new AuthTokenDto
            {
                Token = tokenJson
            };

            return result;
        }
    }
}
