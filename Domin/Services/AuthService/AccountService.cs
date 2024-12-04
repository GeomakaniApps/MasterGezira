using DataLayer.Models;
using Domain.Common;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces.AuthInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuthService
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private string secretKey;
        public AccountService(IConfiguration configuration, ApplicationUserManager userManager)
        {
            _configuration = configuration;
            secretKey = configuration.GetValue<string>("JWT:Secret");
            _userManager = userManager;
        }
        public async Task<UserDto> ResgisterationAsync(RegistrationDto registrationDto, string role)
        {
            var validRoles = typeof(RoleEnum)
                 .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.FlattenHierarchy)
                 .Where(field => field.FieldType == typeof(string))
                 .Select(field => field.GetValue(null).ToString());

            if (!validRoles.Contains(role) || role == RoleEnum.Admin)
            {
                throw new Exception("Invalid role specified.");
            }
            var user = await _userManager.FindByEmailAsync(registrationDto.Email);
            if (user is not null)
                throw new Exception("This user is already exist");
            ApplicationUser newlyCreatedAccount = new ApplicationUser
            {
                Email = registrationDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registrationDto.Email,
                Name = registrationDto.Name,
                NormalizedEmail = registrationDto.Email.ToUpper(),
                SafeNum = registrationDto.SafeNum,
            };

            var password = registrationDto.Password;
            if (!IsPasswordValid(password) || string.IsNullOrEmpty(password))
            {
                throw new Exception(ErrorEnum.PasswordAuth());
            }

            // Attempt to create a new user using the UserManager
            var isSuccessed = await _userManager.CreateAsync(newlyCreatedAccount, registrationDto.Password);

            // If the user creation is successful
            if (isSuccessed.Succeeded)
            {
                // Add the user to the role
                await _userManager.AddToRoleAsync(newlyCreatedAccount, role);

                // Authenticate the newly created user and generate a token
                var token = await AuthenticateAsync(newlyCreatedAccount);

                // Return a UserDTO with the user's information and token
                return new UserDto
                {
                    Id = newlyCreatedAccount.Id,
                    Token = token,
                    Email = newlyCreatedAccount.Email,
                    Name = newlyCreatedAccount.Name,
                };
            }
            else
            {
                // If user creation failed, throw an exception
                throw new Exception("Failed to make an account");
            }
        }
        public async Task<string> AuthenticateAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            // Create an array of claims to represent user information
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // User's unique identifier
                new Claim(ClaimTypes.Email, user.Email), // User's email
                new Claim(ClaimTypes.Name, user.Name), // User's name
                new Claim(ClaimTypes.Role, roles.FirstOrDefault()), // User's role
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID claim
            };

            // Create a security key for signing the JWT, using the secret key from configuration
            var authSignedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            // Create a JWT (JSON Web Token) with issuer, audience, claims, expiration, and signing credentials
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"], // The issuer of the token
                audience: _configuration["JWT:Audience"], // The intended audience of the token
                claims: claims, // User claims
                expires: DateTime.Now.AddDays(30), // Token expiration (e.g., 30 days from now)
                signingCredentials: new SigningCredentials(authSignedKey, SecurityAlgorithms.HmacSha256) // Signing credentials
            );

            // Return the JWT token as a serialized string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<bool> ChangePasswordAsync(string email, string currentPassword, string newPassword)
        {
            // Find the user based on the provided email
            var user = await _userManager.FindByEmailAsync(email);

            // Check if the user exists and the provided current password is valid
            bool isValidPassword = await _userManager.CheckPasswordAsync(user, currentPassword);

            // If the user is not found or the current password is invalid, throw an exception
            if (user == null || !isValidPassword)
            {
                throw new Exception("user is not found or the current password is invalid");
            }

            // Check if the new password is valid
            if (!IsPasswordValid(newPassword))
            {
                throw new Exception(ErrorEnum.PasswordAuth());
            }
            var isAdmin = await _userManager.IsInRoleAsync(user, "admin");

            // If the user has the "admin" role, throw an exception
            if (isAdmin)
            {
                throw new Exception("Changing password for admin user is not allowed");
            }

            // Change the user's password using UserManager
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            // If the password change is successful, return true
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                // If password change failed, throw an exception or handle accordingly
                throw new Exception("Failed to change the password");
            }
        }
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            // Find the user based on the provided email 
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            // Check if the user exists and the provided password is valid
            bool isValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            // If the user is not found or the password is invalid, throw an exception
            if (user == null || !isValid)
            {
                throw new UserInvalidCredentialsException();
            }

            // Get the roles assigned to the user
            var roles = await _userManager.GetRolesAsync(user);

            // Create a JWT (JSON Web Token) for authentication
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey); // Convert the secret key to bytes

            // Create a token descriptor that includes user claims, token expiration, and signing credentials
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()), // Claim for the user's name
                    new Claim(ClaimTypes.Email, user.UserName.ToString()), // Claim for the user's email
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault()), // Claim for the user's role
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),// Claim for the user's ID
                    new Claim("SafeNum", user.SafeNum?.ToString()??"")
                }),
                Expires = DateTime.UtcNow.AddDays(7), // Token expiration set to 7 days from now
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // HMAC-SHA256 signature
            };

            // Create the JWT token based on the token descriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return a UserDTO containing the user's information and the JWT token
            return new UserDto()
            {
                Name = user.UserName,
                Email = user.Email,
                Token = tokenHandler.WriteToken(token), // Serialize the token to a string
            };
        }
        public bool IsPasswordValid(string password)
        {

            if (password.Length > 8 && password.Length < 20)
            {
                bool hasUppercase = password.Any(char.IsUpper);
                bool hasLowercase = password.Any(char.IsLower);
                bool hasDigit = password.Any(char.IsDigit);
                bool hasSpecialCharacter = password.Any(ch => !char.IsLetterOrDigit(ch));

                return hasUppercase && hasLowercase && hasDigit && hasSpecialCharacter;
            }
            return false;
        }
        public Task<IEnumerable<string>> GetRolesAsync()
        {
            var roles = typeof(RoleEnum)
                .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.FlattenHierarchy)
                .Where(field => field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string))
                .Select(field => field.GetValue(null).ToString()); // Extract string values

            return Task.FromResult(roles);
        }
    }
}
