using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DTOS.StudentCoursesDTO;


namespace CoreLayer.DTOS.Course
{
    public record CourseReadDTO
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int Duration { get; set; }
        //public virtual List<StudentCourseDTO> sc { get; set; }

    }
}
