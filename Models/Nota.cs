using Microsoft.Extensions.Primitives;

namespace ProjetoEscola.Models
{
    public class Nota
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public decimal NotaValor { get; set; }
    }
}
