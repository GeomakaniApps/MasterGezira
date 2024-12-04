using DataLayer.Models;
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
        Task<IEnumerable<string>> GetRolesAsync();
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> ResgisterationAsync(RegistrationDto registrationDto, string role);
        Task<string> AuthenticateAsync(ApplicationUser user);
        Task<bool> ChangePasswordAsync(string email, string currentPassword, string newPassword);
    }
}
