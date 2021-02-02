using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagerService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateUserAsync(string userName, string password)
        {           
            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
            };

            await _userManager.CreateAsync(user, password);
        }

        public async Task<bool> ValidateUser(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);            
            return user != null && await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task CreateRole(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };

                await _roleManager.CreateAsync(role);               
            }
        }

        public async Task AddUserToRole(string userName, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }

        public async Task<List<string>> GetUserRoles(string userName)
        {
            var userRoles = new List<string>();

            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                userRoles = new List<string>(await _userManager.GetRolesAsync(user));
            }

            return userRoles;
        }
    }
}
