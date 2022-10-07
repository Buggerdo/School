using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Data.TableModels;

namespace School.Services.Services
{
    public interface ICourseService
    {
        Course CreateCourse(string Title, int Teacher);
        ICollection<Course> GetCourses();
        Course GetCourseById(int id);
    }

    public class CourseService : ICourseService
    {
        private readonly SchoolDbContext _context;

        public CourseService(SchoolDbContext context)
        {
            _context = context;
        }

        public Course CreateCourse(string title, int teacher)
        {
            Course course = new Course() { Title = title, Teacher = teacher };

            _context.Courses.Add(course);
            _context.SaveChanges();

            return course;
        }

        public Course? GetCourseById(int id)
        {
            return _context.Courses.SingleOrDefault(c => c.ID == id);
        }

        public ICollection<Course> GetCourses()
        {
            return _context.Courses.Include("Enrollments").ToList(); //example of eager loading
        }
    }
}
