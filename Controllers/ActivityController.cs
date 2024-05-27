using GAT_PROJECT.Entities;
using GAT_PROJECT.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAT_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityCollection db = new ActivityCollection();
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            return Ok(await db.GetAllActivities()); 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivityDetail(string id)
        {
            return Ok(await db.GetAcivityById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivty([FromBody] Activity activity)
        {
            if (activity == null)
            {
                return BadRequest();
            }
            if (activity.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The Activity should't be empty");
            }
            await db.InsertActivity(activity);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity([FromBody] Activity activity, string id)
        {
            if (activity == null)
            {
                return BadRequest();
            }
            if (activity.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The Activity should't be empty");
            }
            activity.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateActivity(activity);
            return Created("Created", true);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAActivity(string id)
        { 
            await db.DeleteActivity(id);
            return NoContent();
        }
    }

}
