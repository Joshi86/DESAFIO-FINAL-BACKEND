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
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _service;

        public DisciplinaController(IDisciplinaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.ListarTodos());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DisciplinaDTO dto)
        {
            await _service.Criar(dto);
            return Ok("Disciplina cadastrada.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DisciplinaDTO dto)
        {
            try
            {
                await _service.Atualizar(id, dto);
                return Ok("Disicplina Atualizada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Deletar(id);
                return Ok("Disciplina Deletada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
