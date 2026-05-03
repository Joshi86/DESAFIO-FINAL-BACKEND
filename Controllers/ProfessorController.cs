using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.DTOs;
using ProjetoEscola.Models;
using ProjetoEscola.Repositories;
using ProjetoEscola.Services;

using static System.Net.WebRequestMethods;

namespace ProjetoEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _service;

        public ProfessorController(IProfessorService service)
        {
            _service = service;
        }

        // GET

        [HttpGet]
        public async Task<IActionResult> Get()=> Ok(await _service.ListarTodos());

        // POST

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProfessorDTO dto)
        {
            await _service.Criar(dto);
            return Ok("Professor cadastrado.");
        }

        // PUT

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProfessorDTO dto)
        {
            try
            {
                await _service.Atualizar(id, dto);
                return Ok("Professor atualizado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Deletar(id);
                return Ok("Professor removido.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
