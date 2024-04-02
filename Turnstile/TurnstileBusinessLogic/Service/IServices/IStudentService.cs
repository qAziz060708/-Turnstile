using TurnstileBusinessLogic.DTO.ResponseDTOs;
using TurnstileBusinessLogic.DTO.RequestDTOs;

namespace TurnstileBusinessLogic.Service.IServices
{
    public interface IStudentService
    {
        Task<int> AddStudentAsync(StudentRequestDTO studentRequestDTO);

        Task<int> UpdateStudentAsync(StudentRequestDTO studentRequestDTO, int id);

        Task<int> DeleteStudentAsync(int id);

        Task<StudentResponseDTO> GetStudentByIdAsync(int id);

        Task<List<StudentResponseDTO>> GetAllStudentsAsync(string? searchWord);
    }
}