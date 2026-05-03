using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.DTOs
{
    public class ProfessorDTO
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 a 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        public string Cpf { get; set; } = string.Empty;
    }
}
