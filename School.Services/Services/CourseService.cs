using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Data.DTOs;
using School.Data.TableModels;

namespace School.Services.Services
{
    public interface ICourseService
    {
        Course CreateCourse(string Title, string Teacher);
        ICollection<Course> GetCourses();
        Course GetCourseById(int id);
        CourseStudentList GetStudentsForCourseId(int id);
    }

    public class CourseService : ICourseService
    {
        private readonly SchoolDbContext _context;

        public CourseService(SchoolDbContext context)
        {
            _context = context;
        }
        
        public Course CreateCourse(string title, string teacher)
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

        CourseStudentList ICourseService.GetStudentsForCourseId(int id)
        {
            //Course course = _context.Courses.Single(c => c.ID == id);
            //ICollection<Student> students = _context.Enrollments
            //    .Where(e => e.CourseID == id)
            //    .Select(e => e.Student)
            //    .ToList();

            //var csl = new CourseStudentList() 
            //{ 
            //    CourseID = id, 
            //    CourseTitle = course.Title, 
            //    CourseTeacher = course.Teacher, 
            //    Students = students 
            //};

            //return csl;



            return _context.Courses.Where(c => c.ID == id)
                .Select(c => new CourseStudentList()
                {
                    CourseID = c.ID,
                    CourseTitle = c.Title,
                    CourseTeacher = c.Teacher,
                    Students = c.Enrollments.Select(e => e.Student).ToList()
                }).FirstOrDefault();

        }
    }
}
