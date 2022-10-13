using School.Data.TableModels;

namespace School.Data.DTOs
{
    public class CourseStudentList
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseTeacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
