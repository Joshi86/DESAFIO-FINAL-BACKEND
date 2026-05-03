using ProjetoEscola.DTOs;

using ProjetoEscola.Models;

namespace ProjetoEscola.Services
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<Disciplina>> ListarTodos();
        Task Criar(DisciplinaDTO disciplinaDTO);
        Task Atualizar(int id, DisciplinaDTO dto);
        Task Deletar(int id);
    }
}
