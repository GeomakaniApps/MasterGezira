using DataLayer.Models;
using Domain.Common;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces.AuthInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Domain.Services.AuthService;

public class AccountService(IConfiguration _configuration,
                            ApplicationUserManager _userManager) : IAccountService
{
    public async Task<UserResult> ResgisterationAsync(RegistrationDto registrationDto, string role)
    {
        var result = new UserResult();

        var validRoles = Enum.GetNames(typeof(RoleEnum));

        if (!validRoles.Contains(role))
            return Helper.Helper.CreateErrorResult<UserResult>(HttpStatusCode.Unauthorized, "Invalid role specified.");

        var user = await _userManager.FindByEmailAsync(registrationDto.Email);
        if (user is not null)
            return Helper.Helper.CreateErrorResult<UserResult>(HttpStatusCode.NotFound, "This user is already exist.");

        ApplicationUser newlyCreatedAccount = new ApplicationUser
        {
            Email = registrationDto.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = registrationDto.Email,
            Name = registrationDto.Name,
            PasswordHash = registrationDto.Password,
            NormalizedEmail = registrationDto.Email.ToUpper(),
            SafeNum = registrationDto.SafeNum,
        };

        if (!IsPasswordValid(newlyCreatedAccount.PasswordHash) || string.IsNullOrEmpty(newlyCreatedAccount.PasswordHash))
            return Helper.Helper.CreateErrorResult<UserResult>(HttpStatusCode.BadRequest, ErrorEnum.PasswordAuth());

        // Attempt to create a new user using the UserManager
        var isSuccessed = await _userManager.CreateAsync(newlyCreatedAccount, registrationDto.Password);

        if (!isSuccessed.Succeeded)
            return Helper.Helper.CreateErrorResult<UserResult>(HttpStatusCode.BadRequest, "Failed to make an account");

        // Add the user to the role
        await _userManager.AddToRoleAsync(newlyCreatedAccount, role);

        // Authenticate the newly created user and generate a token
        var token = await AuthenticateAsync(newlyCreatedAccount);

        // Return a UserDTO with the user's information and token
        result.User = new UserDto
        {
            Id = newlyCreatedAccount.Id,
            Token = token,
            Email = newlyCreatedAccount.Email,
            Name = newlyCreatedAccount.Name,
        };

        result.SuccessMessage = $"Successfully {role} Created";
        result.StatusCode = HttpStatusCode.Created;
        return result;
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
    public async Task<OperationResult> ChangePasswordAsync(string email, string currentPassword, string newPassword)
    {
        var result = new OperationResult();
        // Find the user based on the provided email
        var user = await _userManager.FindByEmailAsync(email);

        // Check if the user exists and the provided current password is valid
        bool isValidPassword = await _userManager.CheckPasswordAsync(user, currentPassword);

        // If the user is not found or the current password is invalid, throw an exception
        if (user == null || !isValidPassword)
            return Helper.Helper.CreateErrorResult<OperationResult>(HttpStatusCode.BadRequest, "user is not found or the current password is invalid");

        // Check if the new password is valid
        if (!IsPasswordValid(newPassword))
            return Helper.Helper.CreateErrorResult<OperationResult>(HttpStatusCode.BadRequest, ErrorEnum.PasswordAuth());
  
        var isAdmin = await _userManager.IsInRoleAsync(user, "admin");

        // If the user has the "admin" role, throw an exception
        if (isAdmin)
            return Helper.Helper.CreateErrorResult<OperationResult>(HttpStatusCode.BadRequest, "Changing password for admin user is not allowed");

        // Change the user's password using UserManager
        var changeResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

        // If the password change is successful, return true
        if (changeResult.Succeeded)
        {
            result.SuccessMessage = "Password changes successfully";
        }
        else
            return Helper.Helper.CreateErrorResult<OperationResult>(HttpStatusCode.BadRequest, "Failed to change the password");
        return result;
    }
    public async Task<UserResult> LoginAsync(LoginDto loginDto)
    {
        var result=new UserResult();
        // Find the user based on the provided email 
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        // Check if the user exists and the provided password is valid
        bool isValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

        // If the user is not found or the password is invalid, throw an exception
        if (user == null || !isValid)
            return Helper.Helper.CreateErrorResult<UserResult>(HttpStatusCode.BadRequest, " user is not found or the password is invalid");

        // Get the roles assigned to the user
        var roles = await _userManager.GetRolesAsync(user);

        // Create a JWT (JSON Web Token) for authentication
        var tokenHandler = new JwtSecurityTokenHandler();
        var secretKey = _configuration.GetValue<string>("JWT:Secret");
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
        result.User= new UserDto()
        {
            Name = user.UserName,
            Email = user.Email,
            Token = tokenHandler.WriteToken(token), // Serialize the token to a string
        };
        result.SuccessMessage = "Logged in successfully";
        return result;
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
    public RoleResult GetRolesAsync()
    {
        var result = new RoleResult();
        result.RoleDto = Enum.GetNames(typeof(RoleEnum))
                   .Select(role => new RoleDto { Role = role })
                   .ToList();
        if (!result.RoleDto.Any())
            Helper.Helper.CreateErrorResult<RoleResult>(HttpStatusCode.NotFound,ErrorEnum.NotFoundAny("Role"));
        result.SuccessMessage = "Roles returned successfully";
        return result;
    }
}
