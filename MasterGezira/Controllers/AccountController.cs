using Azure;
using DataLayer.Models;
using Domain.Common;
using Domain.DTOs;
using Domain.Interfaces.AuthInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MasterGezira.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        protected OperationResult _operationResult;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
            this._operationResult=new OperationResult();
        }
        [HttpGet]
        [Authorize(Roles = RoleEnum.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<object>> GetRoles()
        {
            _operationResult.Data = _accountService.GetRolesAsync();
            _operationResult.SuccessMessage = "Roles returned successfully";
            _operationResult.StatusCode=HttpStatusCode.OK;
            return Ok(_operationResult);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Login(LoginDto LoginDto)
        {
            _operationResult.Data =await _accountService.LoginAsync(LoginDto);
            _operationResult.SuccessMessage = "Successfully Logged In";
            _operationResult.StatusCode=HttpStatusCode.OK;
            return Ok(_operationResult);
        }
       [HttpPost]
       [Authorize(Roles = RoleEnum.Admin)]
       [ProducesResponseType(StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> RegisterAdmin([FromBody] RegistrationDto registrationDto, [FromQuery] string role)
        {
            _operationResult.Data = await _accountService.ResgisterationAsync(registrationDto, role);
            _operationResult.SuccessMessage = $"Successfully {role} Created";
            _operationResult.StatusCode = HttpStatusCode.Created;
            return Ok(_operationResult);
        }
        [HttpPost]
        [Authorize(Roles = RoleEnum.Admin + "," + RoleEnum.LockerAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> LockerEmployeeRegisteration(RegistrationDto registrationDto)
        {
            _operationResult.Data = await _accountService.ResgisterationAsync(registrationDto, RoleEnum.LockerEmployee);
            _operationResult.SuccessMessage = "Successfully Locker Employee Created";
            _operationResult.StatusCode = HttpStatusCode.Created;
            return Ok(_operationResult);
        }
        [HttpPost]
        [Authorize(Roles = RoleEnum.Admin + "," + RoleEnum.ActivityAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> ActivityEmployeeRegisteration(RegistrationDto registrationDto)
        {
            _operationResult.Data = await _accountService.ResgisterationAsync(registrationDto, RoleEnum.ActivityEmployee);
            _operationResult.SuccessMessage = "Successfully Activity Employee Created";
            _operationResult.StatusCode = HttpStatusCode.Created;
            return Ok(_operationResult);
        }
        [HttpPost]
        [Authorize(Roles = RoleEnum.Admin + "," + RoleEnum.EventAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> EventEmployeeRegisteration(RegistrationDto registrationDto)
        {
            _operationResult.Data = await _accountService.ResgisterationAsync(registrationDto, RoleEnum.EventEmployee);
            _operationResult.SuccessMessage = "Successfully Event Employee Created";
            _operationResult.StatusCode = HttpStatusCode.Created;
            return Ok(_operationResult);
        }
        [HttpPost]
        [Authorize(Roles = RoleEnum.Admin + "," + RoleEnum.ResortAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> ResortEmployeeRegisteration(RegistrationDto registrationDto)
        {
            _operationResult.Data = await _accountService.ResgisterationAsync(registrationDto, RoleEnum.ResortEmployee);
            _operationResult.SuccessMessage = "Successfully Resort Employee Created";
            _operationResult.StatusCode = HttpStatusCode.Created;
            return Ok(_operationResult);
        }
        [HttpPost]
        [Authorize(Roles = RoleEnum.Admin + "," + RoleEnum.TripAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> TripEmployeeRegisteration(RegistrationDto registrationDto)
        {
            _operationResult.Data = await _accountService.ResgisterationAsync(registrationDto, RoleEnum.TripEmployee);
            _operationResult.SuccessMessage = "Successfully Trip Employee Created";
            _operationResult.StatusCode = HttpStatusCode.Created;
            return Ok(_operationResult);
        }
        [HttpPost]
        [Authorize(Roles = RoleEnum.Admin + "," + RoleEnum.AreaAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> AreaEmployeeRegisteration(RegistrationDto registrationDto)
        {
            _operationResult.Data = await _accountService.ResgisterationAsync(registrationDto, RoleEnum.AreaEmployee);
            _operationResult.SuccessMessage = "Successfully Area Employee Created";
            _operationResult.StatusCode = HttpStatusCode.Created;
            return Ok(_operationResult);
        }
        [HttpPost]
        [Authorize(Roles = RoleEnum.Admin + "," + RoleEnum.MembershipAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> MembershipEmployeeRegisteration(RegistrationDto registrationDto)
        {
            _operationResult.Data = await _accountService.ResgisterationAsync(registrationDto, RoleEnum.MembershipEmployee);
            _operationResult.SuccessMessage = "Successfully Membership Employee Created";
            _operationResult.StatusCode = HttpStatusCode.Created;
            return Ok(_operationResult);
        }
        [HttpPost]
        [Authorize(Roles =RoleEnum.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OperationResult>> ChangePassword(string email, string currentPassword, string newPassword)
        {
            await _accountService.ChangePasswordAsync(email, currentPassword, newPassword);
            _operationResult.SuccessMessage = "Password changed successfully";
            _operationResult.StatusCode = HttpStatusCode.OK;
            return Ok(_operationResult);
        }
    }
}
