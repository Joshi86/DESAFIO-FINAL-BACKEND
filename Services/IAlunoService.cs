using ProjetoEscola.DTOs;

using ProjetoEscola.Models;

namespace ProjetoEscola.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> ListarTodos();
        Task<Aluno?> ObterPorId(int id);
        Task Criar(AlunoDTO alunoDTO);
        Task Atualizar(int id, AlunoDTO dto);
        Task Deletar(int id);

        Task<IEnumerable<object>> ObterNotas(int alunoId);

        Task<(double media, bool aprovado)> CalcularMedia(int alunoId);
    }
}
