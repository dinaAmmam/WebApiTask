using CoreLayer.Models;
using InfrastructureLayer.DbContextLayer;
using ServiceLayer.Repositories.Contract;
using ServiceLayer.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Repositories.Implementation
{
    public class StudentCourseRepository:GenericRepository<StudentCourse>, IStudentCourseRepository
    {
        private readonly AppDbContext _context;

        public StudentCourseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
