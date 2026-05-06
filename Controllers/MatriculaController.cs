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
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _service;

        public MatriculaController(IMatriculaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
       => Ok(await _service.ListarTodos());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MatriculaDTO dto)
        {
            try
            {
                await _service.Criar(dto);
                return Ok("Matrícula criada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MatriculaDTO dto)
        {
            try
            {
                await _service.Atualizar(id, dto);
                return NoContent();
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
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
