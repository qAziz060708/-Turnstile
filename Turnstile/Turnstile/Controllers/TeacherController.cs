using AutoMapper;
using FluentValidation;
using TurnstileBusinessLogic.DTO.RequestDTOs;
using TurnstileBusinessLogic.DTO.ResponseDTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnstileBusinessLogic.Service.IServices;

namespace Turnstile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IValidator<TeacherRequestDTO> _validator;

        public TeacherController(ITeacherService teacherService, IValidator<TeacherRequestDTO> validator)
        {
            _teacherService = teacherService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddTeacherAsync([FromForm] TeacherRequestDTO teacherRequestDTO)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(teacherRequestDTO);
                if (validationResult.IsValid)
                {
                    return await _teacherService.AddTeacherAsync(teacherRequestDTO);
                }
                else
                {
                    throw new Exception("You entered the values incorrectly or incompletely, please try to enter them all correctly and completely again.");
                }
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<ActionResult<TeacherResponseDTO>> GetTeacherByIdAsync([FromForm] int id)
        {
            try
            {
                return await _teacherService.GetTeacherByIdAsync(id);
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<TeacherResponseDTO>>> GetAllTeachersAsync([FromForm] string? searchWord)
        {
            try
            {
                return await _teacherService.GetAllTeachersAsync(searchWord);
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("Id")]
        public async Task<ActionResult<int>> UpdateTeacherAsync([FromForm] TeacherRequestDTO teacherRequestDTO, int id)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(teacherRequestDTO);
                if (validationResult.IsValid)
                {
                    return await _teacherService.UpdateTeacherAsync(teacherRequestDTO, id);
                }
                else
                {
                    throw new Exception("Client for update is not available.");
                }
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete("Id")]
        public async Task<ActionResult<int>> DeleteTeacherAsync([FromForm] int id)
        {
            try
            {
                return await _teacherService.DeleteTeacherAsync(id);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}