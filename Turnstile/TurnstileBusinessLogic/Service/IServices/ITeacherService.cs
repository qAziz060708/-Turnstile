using TurnstileBusinessLogic.DTO.ResponseDTOs;
using TurnstileBusinessLogic.DTO.RequestDTOs;

namespace TurnstileBusinessLogic.Service.IServices
{
    public interface ITeacherService
    {
        Task<int> AddTeacherAsync(TeacherRequestDTO teacherRequestDTO);

        Task<int> UpdateTeacherAsync(TeacherRequestDTO teacherRequestDTO, int id);

        Task<int> DeleteTeacherAsync(int id);

        Task<TeacherResponseDTO> GetTeacherByIdAsync(int id);

        Task<List<TeacherResponseDTO>> GetAllTeachersAsync(string? searchWord);
    }
}