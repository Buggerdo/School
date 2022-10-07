using Microsoft.AspNetCore.Mvc;
using School.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;

        public CoursesController(ICourseService service)
        {
            _service = service;
        }


        // GET: api/<CoursesController>
        [HttpGet]
        public ActionResult Get()
        {
            var courses = _service.GetCourses();
            return Ok(courses);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var course = _service.GetCourseById(id);
            if(course == null) return NotFound("There is no course with an ID of " + id);
            return Ok(course);
        }

        // POST api/<CoursesController>
        [HttpPost]
        public ActionResult Post(string title, int teacher)
        {
            return Ok(_service.CreateCourse(title, teacher));
        }
        
        //// PUT api/<CoursesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CoursesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}
