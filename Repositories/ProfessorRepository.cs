using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data;
using ProjetoEscola.Models;

namespace ProjetoEscola.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AppDbContext _context;

        public ProfessorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Professor>> ListarTodos()
            => await _context.Professores.ToListAsync();

        public async Task Adicionar(Professor professor)
        {
            await _context.Professores.AddAsync(professor);
            await _context.SaveChangesAsync();
        }

        // CRUD
        public async Task<Professor?> ObterPorId(int id)
        {
            return await _context.Professores.FindAsync(id);
        }

        public async Task Atualizar(Professor professor)
        {
            _context.Professores.Update(professor);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Professor professor)
        {
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
        }
    }
}
