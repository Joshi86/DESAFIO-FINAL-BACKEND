using ProjetoEscola.Models;
using static System.Net.WebRequestMethods;

namespace ProjetoEscola.Repositories
{
    public interface IMatriculaRepository
    {
        Task<IEnumerable<object>> ListarTodos();
        Task<Matricula_Disciplinas?> ObterPorAlunoEDisciplina(int alunoId, int disciplinaId);
        Task Salvar();
        Task<Matricula_Disciplinas?> ObterPorId(int id);
        Task Adicionar(Matricula_Disciplinas matricula);
        Task Atualizar(Matricula_Disciplinas matricula);
        Task Deletar(Matricula_Disciplinas matricula);

    }
}
