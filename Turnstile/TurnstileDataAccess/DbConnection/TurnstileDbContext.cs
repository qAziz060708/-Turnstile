using Microsoft.EntityFrameworkCore;
using TurnstileDataAccess.Models;

namespace TurnstileDataAccess.DbConnection
{
    public class TurnstileDbContext : DbContext
    {
        public TurnstileDbContext(DbContextOptions<TurnstileDbContext> options) :
            base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}