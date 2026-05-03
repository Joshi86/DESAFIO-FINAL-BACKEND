using ProjetoEscola.DTOs;
using ProjetoEscola.Models;
using ProjetoEscola.Repositories;

namespace ProjetoEscola.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _repository;

        public ProfessorService(IProfessorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Professor>> ListarTodos() => await _repository.ListarTodos();

        public async Task Criar(ProfessorDTO dto)
        {
            var professor = new Professor
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf
            };

            await _repository.Adicionar(professor);
        }

        public async Task Atualizar(int id, ProfessorDTO dto)
        {
            var professor = await _repository.ObterPorId(id);

            if (professor == null)
                throw new Exception("Professor não encontrado.");

            professor.Nome = dto.Nome;
            professor.Cpf = dto.Cpf;

            await _repository.Atualizar(professor);
        }

        public async Task Deletar(int id)
        {
            var professor = await _repository.ObterPorId(id);

            if (professor == null)
                throw new Exception("Professor não encontrado.");

            await _repository.Deletar(professor);
        }
    }
}