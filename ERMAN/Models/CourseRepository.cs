using Microsoft.EntityFrameworkCore;

namespace ERMAN.Models
{
    public class CourseRepository : IDisposable
    {
        private ErmanDbContext context;

        public CourseRepository(ErmanDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Course> GetCourses()
        {
            return context.Courses.ToList();
        }

        public Course GetCourseByID(int id)
        {
            return context.Courses.Find(id);
        }

        public void Insertourse(Course course)
        {
            context.Courses.Add(course);
        }

        public void DeleteCourse(int courseId)
        {
            Course course = context.Courses.Find(courseId);
            context.Courses.Remove(course);
        }

        public void UpdateCourse(Course course)
        {
            context.Entry(course).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }




        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

