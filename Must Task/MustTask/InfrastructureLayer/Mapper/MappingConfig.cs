using AutoMapper;
using CoreLayer.DTOS.Course;
using CoreLayer.DTOS.Student;
using CoreLayer.DTOS.StudentCourse;
using CoreLayer.DTOS.StudentCoursesDTO;
using CoreLayer.Models;
using InfrastructureLayer.DbContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Mapper
{
    public class MappingConfig: Profile 
    {
        public MappingConfig()
        {
            CreateMap<Course , CourseReadDTO>().ReverseMap();
            CreateMap<Course, CourseCreateDTO>().ReverseMap();
            CreateMap<Student , StudentReadDTO>().ReverseMap();
            CreateMap<Student, StudentCreateDTO>().ReverseMap();
            CreateMap<Student , StudentUpdateDTO>().ReverseMap();
            CreateMap<StudentCourse , StudentCourseCreateDTO>().ReverseMap();
            CreateMap<StudentCourse, StudentCourseReadDTO>().ReverseMap();
            CreateMap<StudentCourse, StudentCourseChildReadDTO>().ReverseMap();
        }

        private readonly AppDbContext _context;
        public MappingConfig(AppDbContext context)
        {
            _context = context;

        }
    }
}
