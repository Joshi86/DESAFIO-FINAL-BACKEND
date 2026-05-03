using ProjetoEscola.DTOs;

using ProjetoEscola.Models;

namespace ProjetoEscola.Services
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> ListarTodos();
        Task Criar(ProfessorDTO professorDTO);
        Task Atualizar(int id, ProfessorDTO dto);
        Task Deletar(int id);
    }
}
