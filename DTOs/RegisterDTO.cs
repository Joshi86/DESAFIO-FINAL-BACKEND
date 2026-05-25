using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.DTOs
{
    public class RegisterDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public string Role { get; set; } = "Aluno";
    }
}
