using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Contract;
using CoreLayer.Models;
using CoreLayer.DTOS.Course;
using Microsoft.EntityFrameworkCore;

namespace MustTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;
        private readonly IMapper mapper;
        public CourseController(ICourseRepository _courseRepository, IMapper _mapper)
        {
            courseRepository = _courseRepository;
            mapper = _mapper;
        }
        //get all courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseReadDTO>>> GetAll()
        {
            List<CourseReadDTO> courses = new List<CourseReadDTO>();
            foreach (var item in courseRepository.GetAll())
            {
                CourseReadDTO c = mapper.Map<CourseReadDTO>(item);
                courses.Add(c);
            }
            return Ok(courses);
        }

        //get single course by id
        [HttpGet("{id}")]
        public ActionResult<CourseReadDTO> GetById(int id)
        {
            Course course = courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CourseReadDTO>(course));
        }

        //create course
        [HttpPost]
        public async Task<ActionResult> Add(CourseCreateDTO crs)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var course = mapper.Map<Course>(crs);
                    courseRepository.Create(course);
                    courseRepository.SaveChanges();
                    return CreatedAtAction("GetById", new { id = course.CourseId }, crs);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }

        //edit course by id
        [HttpPut("{id}")]
        public async Task<ActionResult> EditCourse(CourseReadDTO crs, int id)
        {

            if (crs == null) return BadRequest();
            if (crs.CourseId != id) return BadRequest();
            var updated = mapper.Map<Course>(crs);
            courseRepository.Update(updated);
            courseRepository.SaveChanges();
            return CreatedAtAction("GetById", new { id = updated.CourseId }, crs);
        }

        //delete course
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            courseRepository.DeleteCourse(id);

            return Ok();
        }

    }
}
