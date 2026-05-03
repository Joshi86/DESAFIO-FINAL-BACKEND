using Microsoft.Extensions.Primitives;

namespace ProjetoEscola.Models
{
    public class Disciplina
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }

        public List<Turma> Turmas { get; set; } = new();

    }
}
