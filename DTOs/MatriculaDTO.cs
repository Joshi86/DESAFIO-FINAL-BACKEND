using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.DTOs
{
    public class MatriculaDTO
    {
        [Required]
        public int AlunoId { get; set; }

        [Required]
        public int DisciplinaId { get; set; }

        [Required]
        public double Nota { get; set; }
    }
}
