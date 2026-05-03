using Microsoft.Extensions.Primitives;

namespace ProjetoEscola.Models
{
    public class Professor
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;

        public List<Turma> Turmas { get; set; } = new();
    }
}
