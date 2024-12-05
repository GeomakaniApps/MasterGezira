using Azure;
using DataLayer.Models;
using Domain.Common;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces.AuthInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
        [Authorize(Roles = nameof(RoleEnum.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetRoles()
        {
            var result=_accountService.GetRolesAsync();
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login(LoginDto LoginDto)
        {
            var result =await _accountService.LoginAsync(LoginDto);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [Authorize(Roles = nameof(RoleEnum.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RegisterAdmin([FromBody] RegistrationDto registrationDto, string role)
        {
            var result = await _accountService.ResgisterationAsync(registrationDto, role);

            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [Authorize(Roles = nameof(RoleEnum.Admin) + "," + nameof(RoleEnum.LockerAdmin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> LockerEmployeeRegisteration(RegistrationDto registrationDto)
        {
            var result = await _accountService.ResgisterationAsync(registrationDto, nameof(RoleEnum.LockerEmployee));

            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [Authorize(Roles = nameof(RoleEnum.Admin) + "," + nameof(RoleEnum.ActivityAdmin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> ActivityEmployeeRegisteration(RegistrationDto registrationDto)
        {
            var result = await _accountService.ResgisterationAsync(registrationDto, nameof(RoleEnum.ActivityEmployee));

            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [Authorize(Roles = nameof(RoleEnum.Admin) + "," + nameof(RoleEnum.EventAdmin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> EventEmployeeRegisteration(RegistrationDto registrationDto)
        {
            var result = await _accountService.ResgisterationAsync(registrationDto, nameof(RoleEnum.EventEmployee));

            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [Authorize(Roles = nameof(RoleEnum.Admin) + "," + nameof(RoleEnum.ResortAdmin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> ResortEmployeeRegisteration(RegistrationDto registrationDto)
        {
            var result = await _accountService.ResgisterationAsync(registrationDto, nameof(RoleEnum.ResortEmployee));

            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [Authorize(Roles = nameof(RoleEnum.Admin) + "," + nameof(RoleEnum.TripAdmin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> TripEmployeeRegisteration(RegistrationDto registrationDto)
        {
            var result = await _accountService.ResgisterationAsync(registrationDto, nameof(RoleEnum.TripEmployee));

            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [Authorize(Roles = nameof(RoleEnum.Admin) + "," + nameof(RoleEnum.AreaAdmin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> AreaEmployeeRegisteration(RegistrationDto registrationDto)
        {
            var result = await _accountService.ResgisterationAsync(registrationDto, nameof(RoleEnum.AreaEmployee));

            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [Authorize(Roles = nameof(RoleEnum.Admin) + "," + nameof(RoleEnum.MembershipAdmin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> MembershipEmployeeRegisteration(RegistrationDto registrationDto)
        {
            var result = await _accountService.ResgisterationAsync(registrationDto, nameof(RoleEnum.MembershipEmployee));

            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [Authorize(Roles = nameof(RoleEnum.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OperationResult>> ChangePassword(string email, string currentPassword, string newPassword)
        {
            var result=await _accountService.ChangePasswordAsync(email, currentPassword, newPassword);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
    }
}
