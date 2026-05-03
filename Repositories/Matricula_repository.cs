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

        public async Task<IEnumerable<Matricula_Disciplinas>> ListarTodos()
        {
            return await _context.Matriculas.ToListAsync();
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
