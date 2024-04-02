using TurnstileDataAccess.Models;

namespace TurnstileDataAccess.Repository.IRepositories
{
    public interface ITeacherRepository
    {
        Task<int> AddTeacherAsync(Teacher teacher);

        Task<int> UpdateTeacherAsync(Teacher teacher);

        Task<int> DeleteTeacherAsync(Teacher teacher);

        Task<Teacher> GetTeacherByIdAsync(int id);

        Task<List<Teacher>> GetAllTeachersAsync(string? searchWord);
    }
}