using ProjetoEscola.Models;
using static System.Net.WebRequestMethods;

namespace ProjetoEscola.Repositories
{
    public interface IAlunosRepository
    {
        Task<IEnumerable<Aluno>> ListarTodos();
        Task Adicionar(Aluno aluno);

        Task<Aluno?> ObterPorId(int id);
        Task Atualizar(Aluno aluno);
        Task Deletar(Aluno aluno);
    }
}
