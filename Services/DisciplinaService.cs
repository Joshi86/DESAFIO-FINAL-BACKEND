using ProjetoEscola.DTOs;

using ProjetoEscola.Models;
using ProjetoEscola.Repositories;

namespace ProjetoEscola.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _repository;

        public DisciplinaService(IDisciplinaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Disciplina>> ListarTodos()
            => await _repository.ListarTodos();

        public async Task Criar(DisciplinaDTO dto)
        {
            var disciplina = new Disciplina
            {
                Nome = dto.Nome,
                CargaHoraria = dto.CargaHoraria
            };

            await _repository.Adicionar(disciplina);
        }

        public async Task Atualizar(int id, DisciplinaDTO dto)
        {
            var disciplina = await _repository.ObterPorId(id);

            if (disciplina == null)
                throw new Exception("Disciplina não encontrada.");

            disciplina.Nome = dto.Nome;
            disciplina.CargaHoraria = dto.CargaHoraria;

            await _repository.Atualizar(disciplina);
        }

        public async Task Deletar(int id)
        {
            var disciplina = await _repository.ObterPorId(id);

            if (disciplina == null)
                throw new Exception("Disciplina não encontrada.");

            await _repository.Deletar(disciplina);
        }
    }
}
