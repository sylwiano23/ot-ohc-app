using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IUserManager
    {
        Task CreateUserAsync(string userName, string password);
        Task<bool> ValidateUser(string userName, string password);
        Task CreateRole(string roleName);
        Task AddUserToRole(string userName, string roleName);
        Task<List<string>> GetUserRoles(string userName);
    }
}
