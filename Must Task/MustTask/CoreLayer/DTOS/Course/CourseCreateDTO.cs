using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOS.Course
{
    public record CourseCreateDTO
    {
        public string? CourseName { get; set; }
        public int Duration { get; set; }
    }
}
