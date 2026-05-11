using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.DTOs;
using ProjetoEscola.Models;
using ProjetoEscola.Repositories;
using ProjetoEscola.Services;

using static System.Net.WebRequestMethods;

namespace ProjetoEscola.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _service;

        public AlunosController(IAlunoService service)
        {
            _service = service;
        }

        // GET

        [HttpGet]

        public async Task<IActionResult> Get() => Ok(await _service.ListarTodos());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aluno = await _service.ObterPorId(id);

            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpGet("{id}/media")]
        public async Task<IActionResult> GetMedia(int id)
        {
            try
            {
                var resultado = await _service.CalcularMedia(id);

                return Ok(new
                {
                    Media = resultado.media,
                    Status = resultado.aprovado ? "Aprovado" : "Reprovado"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/notas")]
        public async Task<IActionResult> ObterNotas(int id)
        {
            try
            {
                var resultado = await _service.ObterNotas(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST

        [HttpPost]
        public async Task<IActionResult> Post(AlunoDTO alunoDTO)
        {
            try
            {
                await _service.Criar(alunoDTO);
                return Ok("Aluno Cadastrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AlunoDTO dto)
        {
            try
            {
                await _service.Atualizar(id, dto);
                return Ok("Aluno atualizado.");
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
                return Ok("Aluno removido.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

