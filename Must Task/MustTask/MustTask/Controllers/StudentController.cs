using AutoMapper;
using CoreLayer.DTOS.Course;
using CoreLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Contract;
using ServiceLayer.Service.Implementation;
using CoreLayer.DTOS.Student;


namespace MustTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public StudentController(IStudentRepository _studentRepository, IMapper _mapper)
        {
            studentRepository = _studentRepository;
            mapper = _mapper;
            
        }

        //get all students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDTO>>> GetAll()
        {
            List<StudentReadDTO> students = new List<StudentReadDTO>();
            foreach (var item in studentRepository.GetAllStudents())
            {
                StudentReadDTO s = mapper.Map<StudentReadDTO>(item);
                students.Add(s);
            }
            return Ok(students);
        }
        //get single student by id

        [HttpGet("{id}")]
        public ActionResult<StudentReadDTO> GetById(int id)
        {
            Student student = studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StudentReadDTO>(student));
        }

        //add student
        [HttpPost]
        public async Task<ActionResult> Add(StudentCreateDTO std)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var student = mapper.Map<Student>(std);
                    studentRepository.Create(student);
                    studentRepository.SaveChanges();
                    return CreatedAtAction("GetById", new { id = student.StudentId }, std);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }

        //edit student by id
        [HttpPut("{id}")]
        public async Task<ActionResult> EditStudent(StudentUpdateDTO std, int id)
        {

            if (std == null) return BadRequest();
            if (std.StudentId != id) return BadRequest();
            var updatedStudent = mapper.Map<Student>(std);
            studentRepository.Update(updatedStudent);
            studentRepository.SaveChanges();
            return CreatedAtAction("GetById", new { id = updatedStudent.StudentId }, std);
        }

        //delete student
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            studentRepository.DeleteStudent(id);

            return Ok();
        }
    }
}
