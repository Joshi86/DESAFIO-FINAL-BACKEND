using Microsoft.Extensions.Primitives;

namespace ProjetoEscola.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public string Role { get; set; } = "Aluno";
    }
}
