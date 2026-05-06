using ProjetoEscola.DTOs;

using ProjetoEscola.Models;
using ProjetoEscola.Repositories;

namespace ProjetoEscola.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _repository;

        public MatriculaService(IMatriculaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<object>> ListarTodos()
    => await _repository.ListarTodos();

        public async Task Criar(MatriculaDTO dto)   
        {
            var matricula = new Matricula_Disciplinas
            {
                AlunoId = dto.AlunoId,
                DisciplinaId = dto.DisciplinaId,
                Nota = (double)dto.Nota
            };

            await _repository.Adicionar(matricula);
        }

        public async Task LancarNota(NotaDTO dto)
        {
            var matricula = await _repository.ObterPorAlunoEDisciplina(dto.AlunoId, dto.DisciplinaId);

            if (matricula == null)
            {
                matricula = new Matricula_Disciplinas
                {
                    AlunoId = dto.AlunoId,
                    DisciplinaId = dto.DisciplinaId,
                    Nota = (double)dto.Nota
                };

                await _repository.Adicionar(matricula);
                return;
            }

            matricula.Nota = (double)dto.Nota;

            await _repository.Salvar();
        }
        public async Task Atualizar(int id, MatriculaDTO dto)
        {
            var matricula = await _repository.ObterPorId(id);

            if (matricula == null)
                throw new Exception("Matrícula não encontrada.");

            matricula.AlunoId = dto.AlunoId;
            matricula.Nota = (double)dto.Nota;

            await _repository.Atualizar(matricula);
        }

        public async Task Deletar(int id)
        {
            var matricula = await _repository.ObterPorId(id);

            if (matricula == null)
                throw new Exception("Matrícula não encontrada.");

            await _repository.Deletar(matricula);
        }
    }
}
