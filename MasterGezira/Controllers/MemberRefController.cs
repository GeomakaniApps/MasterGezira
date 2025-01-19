using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MasterGezira.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberRefController : ControllerBase
    {
        private readonly IMemberRefService _memberRefService;

        public MemberRefController(IMemberRefService memberRefService)
        {
            _memberRefService = memberRefService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(MemberRefDto memberRefDto)
        {
            var result = await _memberRefService.CreateAsync(memberRefDto);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> GetAll()
        //{
        //    var result = await _memberRefService.GetAllAsync();
        //    if (!result.Success)
        //        return StatusCode((int)result.StatusCode, result.ErrorMessage);

        //    return StatusCode((int)result.StatusCode, result);
        //}

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _memberRefService.GetAsync(id);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(int id, MemberRefDto memberRefDto)
        {
            var result = await _memberRefService.UpdateAsync(id, memberRefDto);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id,[Required]string deletionReason)
        {
            var result = await _memberRefService.DeleteAsync(id,deletionReason);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UnArchive(int id)
        {
            var result = await _memberRefService.UnArchiveAsync(id);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
    }
}
