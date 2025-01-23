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

        #region Get All User Names
        [HttpGet]
        public async Task<IActionResult> GetAllUserNames()
        {
            var userNames = await _context.Users.Select(u => u.UserName).ToListAsync();
            return Ok(userNames);
        }
        #endregion

        #region Get One User Name By ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneUserName(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound($"user with the user id of {id} is not found");
            }
            return Ok(user.UserName);
        }
        #endregion

        #region Update User Name
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserName(int id, [FromBody] string newUserName)
        {
            if (string.IsNullOrEmpty(newUserName))
            {
                return BadRequest("Username cannot be null or empty.");
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} not found");
            }

            user.UserName = newUserName;
            await _context.SaveChangesAsync();

            return Ok(user);
        }
        #endregion

        #region Delete User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Create User
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Email))
            {
                return BadRequest("Username and Email are required.");
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllUserNames), new { id = user.Id }, user);
        }
        #endregion
    }
}