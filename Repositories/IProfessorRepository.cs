using ProjetoEscola.Models;

namespace ProjetoEscola.Repositories
{
    public interface IProfessorRepository
    {
      Task<IEnumerable<Professor>> ListarTodos();
      Task Adicionar(Professor professor);

        Task<Professor?> ObterPorId(int id);
        Task Atualizar(Professor professor);
        Task Deletar(Professor professor);

    }
}
