using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data;
using ProjetoEscola.DTOs;
using ProjetoEscola.Models;
using ProjetoEscola.Repositories;
using ProjetoEscola.Services;

using static System.Net.WebRequestMethods;

namespace ProjetoEscola.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class NotasController : ControllerBase
        {
            private readonly AppDbContext _context;

            public NotasController(AppDbContext context)
            {
                _context = context;
            }

            // GET: api/notas
            [HttpGet]
            public IActionResult Get()
            {
                var notas = _context.Notas
                    .Include(n => n.Aluno)
                    .Include(n => n.Disciplina)
                    .Select(n => new
                    {
                        id = n.Id,
                        alunoId = n.AlunoId,
                        disciplinaId = n.DisciplinaId,
                        aluno = n.Aluno.Nome,
                        disciplina = n.Disciplina.Nome,
                        nota = n.NotaValor
                    })
                    .ToList();

                return Ok(notas);
            }

            // GET: api/notas/aluno/1
            [HttpGet("aluno/{alunoId}")]
            public IActionResult GetByAluno(int alunoId)
            {
                var notas = _context.Notas
                    .Include(n => n.Disciplina)
                    .Where(n => n.AlunoId == alunoId)
                    .Select(n => new
                    {
                        disciplina = n.Disciplina.Nome,
                        nota = n.NotaValor
                    })
                    .ToList();

                return Ok(notas);
            }

            // POST: api/notas
            [HttpPost]
            public IActionResult Post([FromBody] NotaDTO dto)
            {
                if (dto.Nota < 0 || dto.Nota > 10)
                    return BadRequest("A nota deve estar entre 0 e 10.");

            var alunoExiste = _context.Alunos.Any(a => a.ID == dto.AlunoId);

            var disciplinaExiste = _context.Disciplinas.Any(d => d.ID == dto.DisciplinaId);

            if (!alunoExiste || !disciplinaExiste)
                    return BadRequest("Aluno ou disciplina inválidos.");

                var nota = new Nota
                {
                    AlunoId = dto.AlunoId,
                    DisciplinaId = dto.DisciplinaId,
                    NotaValor = dto.Nota
                };

                _context.Notas.Add(nota);
                _context.SaveChanges();

                return Ok(nota);
            }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NotaDTO dto)
        {
            var nota = _context.Notas.FirstOrDefault(n => n.Id == id);

            if (nota == null)
                return NotFound();

            if (dto.Nota < 0 || dto.Nota > 10)
                return BadRequest("A nota deve estar entre 0 e 10.");

            nota.AlunoId = dto.AlunoId;
            nota.DisciplinaId = dto.DisciplinaId;
            nota.NotaValor = dto.Nota;

            _context.SaveChanges();

            return Ok(nota);
        }

        // DELETE: api/notas/1
        [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var nota = _context.Notas.FirstOrDefault(n => n.Id == id);

                if (nota == null)
                    return NotFound();

                _context.Notas.Remove(nota);
                _context.SaveChanges();

                return Ok("Nota removida com sucesso.");
            }
        }
    }


