using DataLayer.Models;
using Domain.Common;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.AuthInterfaces
{
    public interface IAccountService
    {
        RoleResult GetRolesAsync();
        Task<UserResult> LoginAsync(LoginDto loginDto);
        Task<UserResult> ResgisterationAsync(RegistrationDto registrationDto, string role);
        Task<string> AuthenticateAsync(ApplicationUser user);
        Task<OperationResult> ChangePasswordAsync(string email, string currentPassword, string newPassword);
    }
}
