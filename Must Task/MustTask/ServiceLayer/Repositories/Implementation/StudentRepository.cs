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
    public class StudentRepository:GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students
                .Include(s => s.StudentCourses)
                .ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students
                           .Include(p => p.StudentCourses)
                           //.ThenInclude(a => a.Student)
                           .FirstOrDefault(p => p.StudentId == id);
        }


        //to remove student and remove it from courses too
        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);

            if (student != null)
            {
                // remove the course from each student
                foreach (var studentCourse in student.StudentCourses)
                {
                    var course = _context.Courses.FirstOrDefault(c => c.CourseId == studentCourse.CourseId);
                    if (course != null)
                    {
                        var studentCourseToRemove = course.StudentCourses.FirstOrDefault(sc => sc.StudentId == id);
                        if (studentCourseToRemove != null)
                        {
                            course.StudentCourses.Remove(studentCourseToRemove);
                        }
                    }
                }
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }


    }
}
