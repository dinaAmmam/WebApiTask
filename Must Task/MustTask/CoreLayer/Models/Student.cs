using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? Name { get; set; }
        //[Range(10, 30, ErrorMessage = "range validator")]
        public int Age { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<StudentCourse>? StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
