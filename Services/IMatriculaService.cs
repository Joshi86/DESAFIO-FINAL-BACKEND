using ProjetoEscola.DTOs;

using ProjetoEscola.Models;
using ProjetoEscola.Repositories;

namespace ProjetoEscola.Services
{
    public interface IMatriculaService
    {
        Task<IEnumerable<object>> ListarTodos();
        Task Criar(MatriculaDTO dto);
        Task Atualizar(int id, MatriculaDTO dto);
        Task Deletar(int id);
        Task LancarNota(NotaDTO dto);
    }
}
