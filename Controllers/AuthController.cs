using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Data;
using ProjetoEscola.DTOs;
using ProjetoEscola.Models;

namespace ProjetoEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (_context.Usuarios.Any(u => u.Username == dto.Username))
                return BadRequest("Usuário já existe");

            var user = new Usuario
            {
                Username = dto.Username,
                Senha = dto.Senha
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Usuário cadastrado");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var user = _context.Usuarios
                .FirstOrDefault(u => u.Username == dto.Usuario && u.Senha == dto.Senha);

            if (user == null)
                return Unauthorized("Usuário ou senha inválidos");

            return Ok(new { token = "fake-token" });
        }

    }
}
