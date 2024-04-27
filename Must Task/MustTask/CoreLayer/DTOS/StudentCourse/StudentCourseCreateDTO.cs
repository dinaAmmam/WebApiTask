using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOS.StudentCoursesDTO
{
    public record StudentCourseCreateDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

    }
}
