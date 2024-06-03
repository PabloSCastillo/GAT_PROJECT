using GAT_PROJECT.Entities;
using GAT_PROJECT.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAT_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseCollection db = new CourseCollection();
  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return Ok(await db.GetAllCourses());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourseDetail(string id)
        {
            return Ok(await db.GetCourseById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest();
            }
            await db.InsertCourse(course);
            return Created("Created", true);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] Course course, string id)
        {
            if (course == null)
            {
                return BadRequest();
            }
            course.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateCourse(course);
            return Created("Created", true);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(string id)
        { 
            await db.DeleteCourse(id);
            return NoContent(); 
        }
    }
}
