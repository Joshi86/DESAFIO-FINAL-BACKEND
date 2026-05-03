using Microsoft.Extensions.Primitives;

namespace ProjetoEscola.Models
{
    public class Aluno
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }

        public List<Matricula_Disciplinas> Matriculas { get; set; } = new();
    }
}
