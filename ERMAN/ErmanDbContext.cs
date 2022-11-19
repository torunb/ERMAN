using ERMAN.Models;
using Microsoft.EntityFrameworkCore;

namespace ERMAN
{
    public class ErmanDbContext:DbContext
    {
        public ErmanDbContext(DbContextOptions<ErmanDbContext> options) : base(options)
        {

        }

        public DbSet<Student> StudentTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
