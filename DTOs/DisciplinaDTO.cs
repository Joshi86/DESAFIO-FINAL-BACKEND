using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.DTOs
{
    public class DisciplinaDTO
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 a 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        public int CargaHoraria { get; set; }
    }
}
    
