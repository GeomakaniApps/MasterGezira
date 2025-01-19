using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer.Models;
using DataLayer.Services.Pagination;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Domain.DTOs.GetMemberDto;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace MasterGezira.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController(IMemberService _memberService): ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(MemberDto  memberDto)
        {
            var result = await _memberService.CreateAsync(memberDto);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll()
        {
            var result = await _memberService.GetAllAsync();
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _memberService.GetByIdAsync(id);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromQuery]int id, MemberDto memberDto)
        {
            var result = await _memberService.UpdateAsync(id, memberDto);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id,[Required] string deletionReason)
        {
            var result = await _memberService.DeleteAsync(id,deletionReason);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> Filter(List<FilterDTO> filterDTOs , [FromQuery] UserParams userParams)
        //{
        //    List<string> properties = new List<string> { "City" };
        //    var result =  _FilterReposatory.Filter(filterDTOs ,userParams ,includeProperties : properties);
        //    //if (!result.Success)
        //    //    return StatusCode((int)result.StatusCode, result.ErrorMessage);

        //    //return StatusCode((int)result.StatusCode, result);
        //}
        public async Task<ActionResult<GetMemberResult>> Filter([FromBody] List<FilterDTO> filterDTOs, [FromQuery] UserParams userParams)
        {
            if (filterDTOs == null || !filterDTOs.Any())
            {
                return BadRequest("Please provide valid filter conditions.");
            }

            // استدعاء الميثود من الـ Service
            var result = await _memberService.Filter(filterDTOs, userParams);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                return StatusCode((int)result.StatusCode, result.ErrorMessage);
            }

            return Ok(result);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UnArchive(int id)
        {
            var result = await _memberService.UnArchiveAsync(id);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }

    }
}
