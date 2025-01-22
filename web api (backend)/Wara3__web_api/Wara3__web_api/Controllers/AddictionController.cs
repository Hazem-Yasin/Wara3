using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wara3__web_api.Models;

namespace Wara3__web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddictionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AddictionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get All Addiction Names
        [HttpGet]
        public async Task<IActionResult> GetAllAddictionNames()
        {
            var addictionNames = await _context.Addictions.Select(x => x.Name).ToListAsync();
            return Ok(addictionNames);
        }
        #endregion

        #region Update Addiction Name
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddictionName(int id, [FromBody] string newAddictionName)
        {
            if (string.IsNullOrEmpty(newAddictionName))
            {
                return BadRequest("Addiction name cannot be null or empty.");
            }

            var addiction = await _context.Addictions.FindAsync(id);
            if (addiction == null)
            {
                return NotFound($"Addiction with id {id} not found");
            }

            addiction.Name = newAddictionName;
            await _context.SaveChangesAsync();

            return Ok(addiction);
        }
        #endregion

        #region Delete Addiction
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddiction(int id)
        {
            var addiction = await _context.Addictions.FindAsync(id);
            if (addiction == null)
            {
                return NotFound($"Addiction with id {id} not found");
            }

            _context.Addictions.Remove(addiction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Create Addiction
        [HttpPost]
        public async Task<IActionResult> CreateAddiction([FromBody] Addiction addiction)
        {
            if (addiction == null)
            {
                return BadRequest("Invalid addiction data.");
            }

            if (string.IsNullOrEmpty(addiction.Name))
            {
                return BadRequest("Addiction name is required.");
            }

            await _context.Addictions.AddAsync(addiction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllAddictionNames), new { id = addiction.Id }, addiction);
        }
        #endregion
    }
}