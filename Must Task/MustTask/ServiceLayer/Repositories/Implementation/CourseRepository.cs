using CoreLayer.Models;
using InfrastructureLayer.DbContextLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implementation
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {

        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //to remove course and remove it from students too
        public void DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);

            if (course != null)
            {
                // remove the course from each student
                foreach (var studentCourse in course.StudentCourses)
                {
                    var student = _context.Students.FirstOrDefault(s => s.StudentId == studentCourse.StudentId);
                    if (student != null)
                    {
                        var studentCourseToRemove = student.StudentCourses.FirstOrDefault(sc => sc.CourseId == id);
                        if (studentCourseToRemove != null)
                        {
                            student.StudentCourses.Remove(studentCourseToRemove);
                        }
                    }
                }
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }


    }
}
