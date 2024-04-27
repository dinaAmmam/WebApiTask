using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<StudentCourse>? StudentCourses { get; set; } = new HashSet<StudentCourse>();

    }
}
