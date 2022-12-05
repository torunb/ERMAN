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

        public DbSet<FAQItem> FAQTable { get; set; }
        public DbSet<StudentPlacement> StudentPlacements { get; set; }

        public DbSet<Instructor> InstructorTable { get; set; }
        
        public DbSet<Coordinator> CoordinatorTable { get; set; }

        public DbSet<Authentication> AuthenticationTable { get; set; }

        public DbSet<University> UniversityTable { get; set; }

        public DbSet<Todo> TodoTable { get; set; }

        public DbSet<Faq> FaqTable { get; set; }

        public DbSet<Course> CourseTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ERMAN.Models.StudentUser> StudentUserTable { get; set; }
    }
}
