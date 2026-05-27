    using System.ComponentModel.DataAnnotations;

    namespace ProjetoEscola.DTOs

    {
        public class NotaDTO
        {
            public int AlunoId { get; set; }
            public int DisciplinaId { get; set; }
            public decimal Nota { get; set; }
        }
    }
