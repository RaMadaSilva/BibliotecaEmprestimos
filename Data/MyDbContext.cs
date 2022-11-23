using BibliotecaEmprestimos.Models;
using Microsoft.EntityFrameworkCore;


namespace BibliotecaEmprestimos.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Leitor> Leitores { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Server=RMATEIA-SILVA, 1433;Database=Biblioteca;User Id=sa;Password=1q2w3e4r@#$");
        }

    }
}