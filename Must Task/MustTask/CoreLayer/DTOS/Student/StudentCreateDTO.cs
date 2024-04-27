using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOS.Student
{
    public record StudentCreateDTO
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }

    }
}
