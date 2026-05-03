using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data;
using ProjetoEscola.Models;
using static System.Net.WebRequestMethods;

namespace ProjetoEscola.Repositories
{
    // conexao
    public class AlunoRepository : IAlunosRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        // busca o dado
        public async Task<IEnumerable<Aluno>> ListarTodos()
        {
            return await _context.Alunos.ToListAsync();
        }

        // salvar no banco
        public async Task Adicionar(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();
        }

        // CRUD

        public async Task<Aluno?> ObterPorId(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task Atualizar(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<Aluno?> ObterComNotas(int id)
        {
            return await _context.Alunos
                .Include(a => a.Matriculas)
                .FirstOrDefaultAsync(a => a.ID == id);
        }

    }
}
