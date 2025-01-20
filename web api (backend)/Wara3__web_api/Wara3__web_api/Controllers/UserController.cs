using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wara3__web_api.Models;

namespace Wara3__web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        #region GetAllUserNames
        [HttpGet]
        public async Task<IActionResult> GetAllUserNames()
        {
            var userNames = await _context.Users.Select(u => u.UserName).ToListAsync();
            return Ok(userNames);
        }
        #endregion
        #region UpdateUserName
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserName(int id, [FromBody] string newUserName)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} not found");
            }
            user.UserName = newUserName;
            await _context.SaveChangesAsync();
            return Ok($"User name updated to {newUserName}");
        }
        #endregion
        #region DeleteUser
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound($"user with the user id {id} is not found");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok($"user with the user id of {id} have been deleted");
        }
        #endregion
        #region CreateUser
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            // Return the result
            //return CreatedAtAction(nameof(GetAllUserNames), new { id = user.Id }, user);
            return Ok($"user {user} have been create already");
        }
        #endregion


    }
}
