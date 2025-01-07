using Microsoft.AspNetCore.Mvc; // Provides attributes and classes for building RESTful APIs, such as ControllerBase and Route.
using Microsoft.EntityFrameworkCore; // Provides Entity Framework Core functionalities like database queries.
using System.Threading.Tasks;
using Wara3__web_api; // Allows asynchronous programming with Task.

[ApiController] // Indicates that this class is an API controller, enabling features like automatic model validation and binding.
[Route("api/[controller]")] // Specifies the route for the controller. [controller] is a placeholder that gets replaced by the controller name ("User" here).
public class UserController : ControllerBase // Inherits from ControllerBase, which is a base class for API controllers (without views).
{
    private readonly ApplicationDbContext _context; // Represents the database context for accessing and manipulating data.

    // Constructor: Initializes the controller with the ApplicationDbContext instance (dependency injection).
    public UserController(ApplicationDbContext context)
    {
        _context = context; // Assigns the injected context to the private field _context for use in the controller methods.
    }

    // GET: api/user
    [HttpGet] // Maps this method to an HTTP GET request for the "api/user" endpoint.
    public async Task<IActionResult> GetAllUsers()
    {
        // Retrieves all users from the database asynchronously.
        var users = await _context.Users.ToListAsync();
        
        // Returns the list of users with a 200 OK HTTP status code.
        return Ok(users);
    }

    // GET: api/user/{id}
    [HttpGet("{id}")] // Maps this method to an HTTP GET request for "api/user/{id}" where {id} is a placeholder for the user's ID.
    public async Task<IActionResult> GetUserById(int id)
    {
        // Finds a user in the database by their ID asynchronously.
        var user = await _context.Users.FindAsync(id);

        // If no user is found, return a 404 Not Found response with an error message.
        if (user == null)
        {
            return NotFound(new { Message = "User not found" }); // Creates a JSON object with an error message.
        }

        // If the user is found, return their details with a 200 OK HTTP status code.
        return Ok(user);
    }
}
