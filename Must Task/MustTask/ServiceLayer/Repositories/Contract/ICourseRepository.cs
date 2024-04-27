using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contract
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        //Delete Course
        void DeleteCourse(int id);
    }
}
