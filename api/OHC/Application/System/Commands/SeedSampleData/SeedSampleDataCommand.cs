using System.Threading;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IUserManager _userManager;

        public SeedSampleDataCommandHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            await _userManager.CreateRole(UserRole.User.GetName());
            await _userManager.CreateRole(UserRole.Administrator.GetName());

            await _userManager.CreateUserAsync("Admin", "AdminPassword!@#456");
            await _userManager.CreateUserAsync("User", "UserPassword!@#456");

            await _userManager.AddUserToRole("Admin", UserRole.Administrator.GetName());
            await _userManager.AddUserToRole("User", UserRole.User.GetName());

            return Unit.Value;
        }
    }
}
