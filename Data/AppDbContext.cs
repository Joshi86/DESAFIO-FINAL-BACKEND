using Microsoft.EntityFrameworkCore;

using ProjetoEscola.Models;

namespace ProjetoEscola.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Nota> Notas { get; set; }


        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Matricula_Disciplinas> Matriculas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        // Configuração

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Matricula_Disciplinas>()
                .HasOne(m => m.Disciplina)
                .WithMany(d => d.Matriculas)
                .HasForeignKey(m => m.DisciplinaId);

            modelBuilder.Entity<Turma>()
                .HasOne(t => t.Professor)
                .WithMany(p => p.Turmas)
                .HasForeignKey(t => t.ProfessorId);

            modelBuilder.Entity<Turma>()
                .HasOne(t => t.Disciplina)
                .WithMany(d => d.Turmas)
                .HasForeignKey(t => t.DisciplinaId);


            modelBuilder.Entity<Nota>()
                .HasOne(n => n.Aluno)
                .WithMany()
                .HasForeignKey(n => n.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Nota>()
                .HasOne(n => n.Disciplina)
                .WithMany()
                .HasForeignKey(n => n.DisciplinaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
