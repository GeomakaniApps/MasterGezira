using Domain.DTOs;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterGezira.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QualificationController(IQualificationService _qualificationService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(QualificationDto qualificationDto)
        {
            var result = await _qualificationService.CreateAsync(qualificationDto);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll()
        {
            var result = await _qualificationService.GetAllAsync();
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _qualificationService.GetAsync(id);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(int id, QualificationDto qualificationDto)
        {
            var result = await _qualificationService.UpdateAsync(id, qualificationDto);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _qualificationService.DeleteAsync(id);
            if (!result.Success)
                return StatusCode((int)result.StatusCode, result.ErrorMessage);

            return StatusCode((int)result.StatusCode, result);
        }
    }
}
