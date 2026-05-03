using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.DTOs;

namespace ProjetoEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            // SIMPLES (pra sua atividade)
            if (dto.Usuario == "admin" && dto.Senha == "123")
            {
                return Ok(new { token = "fake-token" });
            }

            return Unauthorized("Usuário ou senha inválidos");
        }
    }
}
