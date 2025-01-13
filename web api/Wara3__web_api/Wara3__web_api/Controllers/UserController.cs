using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var userNames = await _context.Users
                                          .Select(u => u.UserName)
                                          .ToListAsync();

            return Ok(userNames);
        }
        #endregion

        #region UpdateUserName
        // This is a PUT endpoint that will allow the updating of a user's name based on the user ID.
        [HttpPut("{id}")]  // This attribute specifies that this method will handle PUT requests with a user ID as part of the URL.
        public async Task<IActionResult> UpdateUserName(int id, [FromBody] string newUserName)
        {
            // Find the user by the given ID from the database
            var user = await _context.Users.FindAsync(id);

            // If no user is found, return a 404 Not Found response
            if (user == null)
            {
                return NotFound($"User with id {id} not found");
            }

            // Update the UserName property with the new user name received in the request body
            user.UserName = newUserName;

            // Save the changes to the database asynchronously
            await _context.SaveChangesAsync();

            // Return a successful response with the updated user name
            return Ok($"User name updated to {newUserName}");
        }
        #endregion


    }
}
