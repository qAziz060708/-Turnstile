using Microsoft.EntityFrameworkCore;
using TurnstileDataAccess.DbConnection;
using TurnstileDataAccess.Models;
using TurnstileDataAccess.Repository.IRepositories;

namespace TurnstileDataAccess.Repository.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TurnstileDbContext _turnstileDbContext;

        public TeacherRepository(TurnstileDbContext turnstileDbContext)
        {
            _turnstileDbContext = turnstileDbContext;
        }

        public async Task<int> AddTeacherAsync(Teacher teacher)
        {
            try
            {
                _turnstileDbContext.Teachers.Add(teacher);
                await _turnstileDbContext.SaveChangesAsync();
                return teacher.TeacherId;
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

        public async Task<int> DeleteTeacherAsync(Teacher teacher)
        {
            try
            {
                _turnstileDbContext.Teachers.Remove(teacher);
                await _turnstileDbContext.SaveChangesAsync();
                return teacher.TeacherId;
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

        public async Task<List<Teacher>> GetAllTeachersAsync(string? searchWord)
        {
            try
            {
                var allteachers = await _turnstileDbContext.Teachers
                    .Include(x => x.Students)
                    .AsSplitQuery()
                    .ToListAsync();
                if (!string.IsNullOrEmpty(searchWord))
                {
                    allteachers = allteachers.Where(n => n.TeacherFirstName.Contains(searchWord) || n.TeacherLastName.Contains(searchWord)).ToList();
                }
                return allteachers;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving Teachers information");
            }
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            try
            {
                return await _turnstileDbContext.Teachers
                    .Include(x =>x.Students)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(u => u.TeacherId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving TeacherById information");
            }
        }

        public async Task<int> UpdateTeacherAsync(Teacher teacher)
        {
            try
            {
                _turnstileDbContext.Teachers.Update(teacher);
                await _turnstileDbContext.SaveChangesAsync();
                return teacher.TeacherId;
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