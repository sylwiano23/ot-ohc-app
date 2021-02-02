using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
    public static class UserRoleExtension
    {
        public static string GetName(this UserRole role)
        {
            return Enum.GetName(typeof(UserRole), role);
        }
    }
}
