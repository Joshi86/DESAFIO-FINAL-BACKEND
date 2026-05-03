using ProjetoEscola.Models;
using static System.Net.WebRequestMethods;

namespace ProjetoEscola.Repositories
{
    public interface IMatriculaRepository
    {
        Task<IEnumerable<Matricula_Disciplinas>> ListarTodos();
        Task<Matricula_Disciplinas?> ObterPorId(int id);
        Task Adicionar(Matricula_Disciplinas matricula);
        Task Atualizar(Matricula_Disciplinas matricula);
        Task Deletar(Matricula_Disciplinas matricula);
    }
}
