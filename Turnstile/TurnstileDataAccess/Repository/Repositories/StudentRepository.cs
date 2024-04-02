using Microsoft.EntityFrameworkCore;
using TurnstileDataAccess.DbConnection;
using TurnstileDataAccess.Models;
using TurnstileDataAccess.Repository.IRepositories;

namespace TurnstileDataAccess.Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly TurnstileDbContext _turnstileDbContext;

        public StudentRepository(TurnstileDbContext turnstileDbContext)
        {
            _turnstileDbContext = turnstileDbContext;
        }

        public async Task<int> AddStudentAsync(Student student)
        {
            try
            {
                _turnstileDbContext.Students.Add(student);
                await _turnstileDbContext.SaveChangesAsync();
                return student.StudentId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was adding changes");
            }
        }

        public async Task<int> DeleteStudentAsync(Student student)
        {
            try
            {
                _turnstileDbContext.Students.Remove(student);
                await _turnstileDbContext.SaveChangesAsync();
                return student.StudentId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<Student>> GetAllStudentsAsync(string? searchWord)
        {
            try
            {
                var allstudents = await _turnstileDbContext.Students
                    .Include(x => x.Teacher)
                    .AsSplitQuery()
                    .ToListAsync();
                if (!string.IsNullOrEmpty(searchWord))
                {
                    allstudents = allstudents.Where(n => n.StudentFirstName.Contains(searchWord) || n.StudentLastName.Contains(searchWord)).ToList();
                }
                return allstudents;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving Student information");
            }
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            try
            {
                return await _turnstileDbContext.Students
                    .Include(x => x.Teacher)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(u => u.StudentId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving StudentById information");
            }
        }

        public async Task<int> UpdateStudentAsync(Student student)
        {
            try
            {
                _turnstileDbContext.Students.Update(student);
                await _turnstileDbContext.SaveChangesAsync();
                return student.StudentId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it updating changes");
            }
        }
    }
}