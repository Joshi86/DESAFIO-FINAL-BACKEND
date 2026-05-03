using Microsoft.Extensions.Primitives;

namespace ProjetoEscola.Models
{
    public class Turma
    {
        public int ID { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public string Horario { get; set; } = string.Empty;
    }
}
