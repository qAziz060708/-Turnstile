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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IValidator<StudentRequestDTO> _validator;

        public StudentController(IStudentService studentService, IValidator<StudentRequestDTO> validator)
        {
            _studentService = studentService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddStudentAsync([FromForm] StudentRequestDTO studentRequestDTO)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(studentRequestDTO);
                if (validationResult.IsValid)
                {
                    return await _studentService.AddStudentAsync(studentRequestDTO);
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
        public async Task<ActionResult<StudentResponseDTO>> GetStudentByIdAsync([FromForm] int id)
        {
            try
            {
                return await _studentService.GetStudentByIdAsync(id);
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
        public async Task<ActionResult<List<StudentResponseDTO>>> GetAllClientsAsync([FromForm] string? searchWord)
        {
            try
            {
                return await _studentService.GetAllStudentsAsync(searchWord);
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
        public async Task<ActionResult<int>> UpdateStudentAsync([FromForm] StudentRequestDTO studentRequestDTO, int id)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(studentRequestDTO);
                if (validationResult.IsValid)
                {
                    return await _studentService.UpdateStudentAsync(studentRequestDTO, id);
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
        public async Task<ActionResult<int>> DeleteStudentAsync([FromForm] int id)
        {
            try
            {
                return await _studentService.DeleteStudentAsync(id);
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