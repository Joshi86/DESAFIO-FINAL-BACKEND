using Microsoft.Extensions.Primitives;

namespace ProjetoEscola.Models
{
    public class Matricula_Disciplinas
    {
        public int ID { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public double Nota { get; set; }
    }
}
