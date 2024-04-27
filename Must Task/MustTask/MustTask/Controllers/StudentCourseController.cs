using AutoMapper;
using CoreLayer.DTOS.Student;
using CoreLayer.DTOS.StudentCourse;
using CoreLayer.DTOS.StudentCoursesDTO;
using CoreLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Repositories.Contract;
using ServiceLayer.Service.Contract;
using ServiceLayer.Service.Implementation;

namespace MustTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseRepository studentCourseRepository;
        private readonly IMapper mapper;

        public StudentCourseController(IStudentCourseRepository _studentCourseRepository , IMapper _mapper)
        {
            studentCourseRepository = _studentCourseRepository;
            mapper = _mapper;
            
        }
        //get all courses with students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentCourseReadDTO>>> GetAll()
        {
            List<StudentCourseReadDTO> S_C = new List<StudentCourseReadDTO>();
            foreach (var item in studentCourseRepository.GetAll())
            {
                StudentCourseReadDTO stCrs = mapper.Map<StudentCourseReadDTO>(item);
                S_C.Add(stCrs);
            }
            return Ok(S_C);
        }

        //get by id
        [HttpGet("{id}")]
        public ActionResult<StudentCourseReadDTO> GetById(int id)
        {
            StudentCourse std_crs = studentCourseRepository.GetById(id);
            if (std_crs == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StudentCourseReadDTO>(std_crs));
        }


        //add courses to students
        [HttpPost]
        public async Task<ActionResult> Add(StudentCourseCreateDTO std_crs)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var SC = mapper.Map<StudentCourse>(std_crs);
                    studentCourseRepository.Create(SC);
                    studentCourseRepository.SaveChanges();
                    return Ok ( std_crs);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        //update

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(StudentCourseReadDTO sc, int id)
        {

            if (sc == null) return BadRequest();
            if (sc.StudentCourseId != id) return BadRequest();
            var updated = mapper.Map<StudentCourse>(sc);
            studentCourseRepository.Update(updated);
            studentCourseRepository.SaveChanges();
            return CreatedAtAction("GetById", new { id = updated.StudentCourseId }, sc);
        }

        //delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            studentCourseRepository.Delete(id);
            studentCourseRepository.SaveChanges();

            return Ok();
        }
    }
}
