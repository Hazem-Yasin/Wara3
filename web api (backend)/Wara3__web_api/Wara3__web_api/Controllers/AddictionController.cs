using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wara3__web_api.Models;

namespace Wara3__web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddictionController : Controller
    {
        public class AddictionsController : ControllerBase
        {
            public readonly ApplicationDbContext _context;
            public AddictionsController(ApplicationDbContext context)
            {
                _context = context;
            }
            #region GetAllAddictionName
            [HttpGet]
            public async Task<IActionResult> GetAllAddictionNames()
            {
                var AddictioNames = await _context.Addictions.Select(x => x.Name).ToListAsync();
                return Ok(AddictioNames);
            }
            #endregion
            #region UpdateAddictionName
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateAddictionName(int id, [FromBody] string newAddictionName, Addiction addiction)
            {
                var user = await _context.Addictions.FindAsync(id);
                if (user == null)
                {
                    return NotFound($"Addiction with id {id} not found");
                }
                addiction.Name = newAddictionName;
                await _context.SaveChangesAsync();
                return Ok($"Addiction name have ben updated to {newAddictionName}");
            }
            #endregion
            #region DeleteAddiction
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAddiction(int id)
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound($"Addiction with the user id {id} is not found");
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Ok($"addiction with the addiction id of {id} is not found");
            }
            #endregion
            #region CreateAddiction
            [HttpPost]
            public async Task<IActionResult> CreateAddiction([FromBody] Addiction addiction)
            {
                if (addiction == null)
                {
                    return BadRequest("Invalid addiction data");
                }
                await _context.Addictions.AddAsync(addiction);
                await _context.SaveChangesAsync();
                return Ok($"addiction {addiction} have been just create");
            }
            #endregion
        }
    }
}
