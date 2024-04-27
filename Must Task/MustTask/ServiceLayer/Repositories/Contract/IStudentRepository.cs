using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contract
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        ////Get All Students
        List<Student> GetAllStudents();

        ////Get Single Student
        Student GetStudentById(int id);

        ////Add Student
        //void Create(Student student);

        //Update Or Edit Student
        //void UpdateStudent(Student student);

        //Delete Student
        void DeleteStudent(int id);
    }
}
