using GenericRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> persons { get; set; }
        public DbSet<Cars> cars { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
    }
}
