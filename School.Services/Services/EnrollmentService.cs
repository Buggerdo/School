using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Data.TableModels;

namespace School.Services.Services
{
    public interface IEnrollmentService
    {
        Enrollment CreateEnrollment(int student, int course);
        ICollection<Enrollment> GetEnrollments();
        Enrollment? GetEnrollmentById(int id);
        ICollection<Enrollment> GetEnrollmentsByStudentId(int id);
    }


    public class EnrollmentService : IEnrollmentService
    {
        private readonly SchoolDbContext _context;

        public EnrollmentService(SchoolDbContext context)
        {
            _context = context;
        }

        public Enrollment CreateEnrollment(int courseId, int studentId)
        {
            Enrollment enrollment = new Enrollment()
            {
                CourseID = courseId,
                StudentID = studentId
            };

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            return enrollment;
        }
        public ICollection<Enrollment> GetEnrollments()
        {
            return _context.Enrollments.ToList();
        }

        public Enrollment? GetEnrollmentById(int id)
        {
            return _context.Enrollments.SingleOrDefault(e => e.ID == id);
        }

        public ICollection<Enrollment> GetEnrollmentsByStudentId(int id)
        {
            
            var e = _context.Enrollments.Include(e => e.Course)
                .Where(e => e.StudentID == id)
                .ToList();
            return e;
        }

    }
}

