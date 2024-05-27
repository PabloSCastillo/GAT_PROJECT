using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GAT_PROJECT.Models;
using GAT_PROJECT.Repositories;

namespace GAT_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserCollection db = new UserCollection();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await db.GetAllUsers());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserDetails(string id)
        {
            return Ok(await db.GetUserById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (user.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The User shouldn't be empty");
            }

            await db.InsertUser(user);

            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] User user, string id)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (user.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The User shouldn't be empty");
            }

            user.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateUser(user);

            return Created("Created", true);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        { 
            await db.DeleteUser(id);
            return NoContent();
        }
    }
}
