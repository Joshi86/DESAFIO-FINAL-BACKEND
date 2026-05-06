using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data;
using ProjetoEscola.Models;
using static System.Net.WebRequestMethods;

namespace ProjetoEscola.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly AppDbContext _context;

        public MatriculaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> ListarTodos()
        {
            return await _context.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Disciplina)
                .Select(m => new
                {
                    id = m.ID,
                    aluno = m.Aluno.Nome,
                    disciplina = m.Disciplina.Nome,
                    nota = m.Nota
                })
                .ToListAsync();
        }

        public async Task<Matricula_Disciplinas?> ObterPorAlunoEDisciplina(int alunoId, int disciplinaId)
        {
            return await _context.Matriculas
              .Include(m => m.Disciplina)
              .Include(m => m.Aluno)
              .FirstOrDefaultAsync(m => m.AlunoId == alunoId && m.DisciplinaId == disciplinaId);
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Matricula_Disciplinas?> ObterPorId(int id)
        {
            return await _context.Matriculas.FindAsync(id);
        }

        public async Task Adicionar(Matricula_Disciplinas matricula)
        {
            await _context.Matriculas.AddAsync(matricula);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Matricula_Disciplinas matricula)
        {
            _context.Matriculas.Update(matricula);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Matricula_Disciplinas matricula)
        {
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
        }
    }
}
