using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DTOS.StudentCourse;
using CoreLayer.DTOS.StudentCoursesDTO;


namespace CoreLayer.DTOS.Student
{
    public record StudentReadDTO
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public virtual List<StudentCourseChildReadDTO> StudentCourses { get; set; }

    }
}
