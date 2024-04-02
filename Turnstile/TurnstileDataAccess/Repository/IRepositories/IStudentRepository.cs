using TurnstileDataAccess.Models;

namespace TurnstileDataAccess.Repository.IRepositories
{
    public interface IStudentRepository
    {
        Task<int> AddStudentAsync(Student student);

        Task<int> UpdateStudentAsync(Student student);

        Task<int> DeleteStudentAsync(Student student);

        Task<Student> GetStudentByIdAsync(int id);

        Task<List<Student>> GetAllStudentsAsync(string? searchWord);
    }
}