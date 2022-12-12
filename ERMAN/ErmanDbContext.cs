using ERMAN.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ERMAN
{
    public class ErmanDbContext:DbContext
    {
        public ErmanDbContext(DbContextOptions<ErmanDbContext> options) : base(options)
        {

        }

        public DbSet<Student> StudentTable { get; set; }

        public DbSet<FAQItem> FAQTable { get; set; }

        public DbSet<Instructor> InstructorTable { get; set; }
        
        public DbSet<Coordinator> CoordinatorTable { get; set; }

        public DbSet<Authentication> AuthenticationTable { get; set; }

        public DbSet<University> UniversityTable { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<Todo> TodoTable { get; set; }

        public DbSet<Checklist> ChecklistTable { get; set; }

        public DbSet<Course> CourseTable { get; set; }
        public DbSet<CourseMapped> CourseMappedTable { get; set; }



        public DbSet<Message> MessageTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
