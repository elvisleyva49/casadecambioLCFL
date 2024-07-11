using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasaDeCambioAPI.Data;
using CasaDeCambioAPI.Models;
using System.Threading.Tasks;

namespace CasaDeCambioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CasaDeCambioContext _context;

        public UsersController(CasaDeCambioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(User loginUser)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Username == loginUser.Username && u.Password == loginUser.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }
    }
}
