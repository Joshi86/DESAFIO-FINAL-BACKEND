using ProjetoEscola.DTOs;

using ProjetoEscola.Models;
using ProjetoEscola.Repositories;

namespace ProjetoEscola.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunosRepository _repository;

        public AlunoService(IAlunosRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Aluno>> ListarTodos() => await _repository.ListarTodos();

        public async Task<Aluno?> ObterPorId(int id)
        {
            return await _repository.ObterPorId(id);
        }

        public async Task Criar(AlunoDTO alunoDTO)
        {
            if (alunoDTO.DataNascimento > DateTime.Now)
                throw new Exception("Não é possível cadastrar uma data de nascimento do futuro.");

            var aluno = new Aluno
            {
                Nome = alunoDTO.Nome,
                Cpf = alunoDTO.Cpf,
                DataNascimento = alunoDTO.DataNascimento
            };

            await _repository.Adicionar(aluno);
        }

        public async Task Atualizar(int id, AlunoDTO dto)
        {
            var aluno = await _repository.ObterPorId(id);

            if (aluno == null)
                throw new Exception("Aluno não encontrado.");

            aluno.Nome = dto.Nome;
            aluno.Cpf = dto.Cpf;
            aluno.DataNascimento = dto.DataNascimento;

            await _repository.Atualizar(aluno);
        }

        public async Task Deletar(int id)
        {
            var aluno = await _repository.ObterPorId(id);

            if (aluno == null)
                throw new Exception("Aluno não encontrado.");

            await _repository.Deletar(aluno);
        }

        public async Task<IEnumerable<object>> ObterNotas(int alunoId)
        {
            var aluno = await _repository.ObterComNotas(alunoId);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            return aluno.Matriculas.Select(m => new
            {
                disciplina = m.Disciplina.Nome,
                nota = m.Nota,
                situacao = m.Nota >= 7 ? "Aprovado" : "Reprovado"
            });
        }

        public async Task<(double media, bool aprovado)> CalcularMedia(int alunoId)
        {
            var aluno = await _repository.ObterPorId(alunoId);

            if (aluno == null)
                throw new Exception("Aluno não encontrado.");

            if (!aluno.Matriculas.Any())
                throw new Exception("Aluno não possui notas.");

            var media = aluno.Matriculas.Average(m => m.Nota);

            bool aprovado = media >= 7.0;

            return (media, aprovado);
        }
    }
}
