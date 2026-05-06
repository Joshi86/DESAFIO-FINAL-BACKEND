using Microsoft.Extensions.Primitives;

namespace ProjetoEscola.Models
{
    public class Disciplina
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }

        public ICollection<Matricula_Disciplinas> Matriculas { get; set; } = new List<Matricula_Disciplinas>();

        public List<Turma> Turmas { get; set; } = new();

    }
}
