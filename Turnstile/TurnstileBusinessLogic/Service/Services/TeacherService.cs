using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TurnstileBusinessLogic.DTO.RequestDTOs;
using TurnstileBusinessLogic.DTO.ResponseDTOs;
using TurnstileBusinessLogic.Service.IServices;
using TurnstileDataAccess.Models;
using TurnstileDataAccess.Repository.IRepositories;
using TurnstileDataAccess.Repository.Repositories;

namespace TurnstileBusinessLogic.Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<int> AddTeacherAsync(TeacherRequestDTO teacherRequestDTO)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                await teacherRequestDTO.formFile.CopyToAsync(memoryStream);
                var fileContent = memoryStream.ToArray();

                var teacher = _mapper.Map<Teacher>(teacherRequestDTO);
                teacher.ContentType = teacherRequestDTO.formFile.ContentType;
                teacher.ContentOfImage = fileContent;
                return await _teacherRepository.AddTeacherAsync(teacher);
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

        public async Task<int> DeleteTeacherAsync(int id)
        {
            try
            {
                var teacherResult = await _teacherRepository.GetTeacherByIdAsync(id);
                if (teacherResult is not null)
                {
                    return await _teacherRepository.DeleteTeacherAsync(teacherResult);
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

        public async Task<List<TeacherResponseDTO>> GetAllTeachersAsync(string? searchWord)
        {
            try
            {
                return _mapper.Map<List<TeacherResponseDTO>>(await _teacherRepository.GetAllTeachersAsync(searchWord));
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

        public async Task<TeacherResponseDTO> GetTeacherByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<TeacherResponseDTO>(await _teacherRepository.GetTeacherByIdAsync(id));
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

        public async Task<int> UpdateTeacherAsync(TeacherRequestDTO teacherRequestDTO, int id)
        {
            {
                try
                {
                    var teacherResult = await _teacherRepository.GetTeacherByIdAsync(id);
                    if (teacherResult is not null)
                    {
                        teacherResult = _mapper.Map<Teacher>(teacherRequestDTO);
                        teacherResult.TeacherId = id;
                        return await _teacherRepository.UpdateTeacherAsync(teacherResult);
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
}