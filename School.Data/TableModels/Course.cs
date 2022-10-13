using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.TableModels
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        
        [StringLength(50)]
        public string Teacher { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
