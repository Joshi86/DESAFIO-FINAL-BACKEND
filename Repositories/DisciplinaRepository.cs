using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data;
using ProjetoEscola.Models;

using static System.Net.WebRequestMethods;

namespace ProjetoEscola.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly AppDbContext _context;

        public DisciplinaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Disciplina>> ListarTodos()
            => await _context.Disciplinas.ToListAsync();

        public async Task Adicionar(Disciplina disciplina)
        {
            await _context.Disciplinas.AddAsync(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task<Disciplina?> ObterPorId(int id)
        {
            return await _context.Disciplinas.FindAsync(id);
        }

        public async Task Atualizar(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Disciplina disciplina)
        {
            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();
        }

    }
}
