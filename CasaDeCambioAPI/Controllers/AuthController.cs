using Microsoft.AspNetCore.Mvc;
using CasaDeCambioAPI.Models;
using CasaDeCambioAPI.Data;
using BCrypt.Net;

namespace CasaDeCambioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CasaDeCambioContext _context;

        public AuthController(CasaDeCambioContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == loginUser.Username);

            if (user == null)
            {
                // Si no se encuentra el usuario, devolver Unauthorized
                return Unauthorized("Invalid username or password");
            }

            // Verificar la contraseña utilizando BCrypt
            if (!BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password))
            {
                // Si la contraseña no coincide, devolver Unauthorized
                return Unauthorized("Invalid username or password");
            }

            // Si las credenciales son válidas, devolver Ok
            return Ok("Login successful");
        }
    }
}
