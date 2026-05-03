using ProjetoEscola.Models;

namespace ProjetoEscola.Repositories
{
    public interface IDisciplinaRepository
    {
        Task<IEnumerable<Disciplina>> ListarTodos();
        Task Adicionar(Disciplina disciplina);
        Task<Disciplina?> ObterPorId(int id);
        Task Atualizar(Disciplina disciplina);
        Task Deletar(Disciplina disciplina);
    }
}

