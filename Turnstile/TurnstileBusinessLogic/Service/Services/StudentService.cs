using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TurnstileBusinessLogic.DTO.RequestDTOs;
using TurnstileBusinessLogic.DTO.ResponseDTOs;
using TurnstileBusinessLogic.Service.IServices;
using TurnstileDataAccess.Models;
using TurnstileDataAccess.Repository.IRepositories;

namespace TurnstileBusinessLogic.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<int> AddStudentAsync(StudentRequestDTO studentRequestDTO)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                await studentRequestDTO.formFile.CopyToAsync(memoryStream);
                var fileContent = memoryStream.ToArray();

                var student = _mapper.Map<Student>(studentRequestDTO);
                student.ContentType = studentRequestDTO.formFile.ContentType;
                student.ContentOfImage = fileContent;
                return await _studentRepository.AddStudentAsync(student);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"{ex.Message} , {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} , {ex.StackTrace}");
            }
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            try
            {
                var studentResult = await _studentRepository.GetStudentByIdAsync(id);
                if (studentResult is not null)
                {
                    return await _studentRepository.DeleteStudentAsync(studentResult);
                }
                else
                {
                    throw new Exception("Object cannot be deleted");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<StudentResponseDTO>> GetAllStudentsAsync(string? searchWord)
        {
            try
            {
                return _mapper.Map<List<StudentResponseDTO>>(await _studentRepository.GetAllStudentsAsync(searchWord));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} , {ex.StackTrace}");
            }
        }

        public async Task<StudentResponseDTO> GetStudentByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<StudentResponseDTO>(await _studentRepository.GetStudentByIdAsync(id));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} , {ex.StackTrace}");
            }
        }

        public async Task<int> UpdateStudentAsync(StudentRequestDTO studentRequestDTO, int id)
        {
            try
            {
                var studentResult = await _studentRepository.GetStudentByIdAsync(id);
                if (studentResult is not null)
                {
                    studentResult = _mapper.Map<Student>(studentRequestDTO);
                    studentResult.StudentId = id;
                    return await _studentRepository.UpdateStudentAsync(studentResult);
                }
                else
                {
                    throw new Exception("Object cannot be updated.");
                }
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed.");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was updating changes.");
            }
        }
    }
}