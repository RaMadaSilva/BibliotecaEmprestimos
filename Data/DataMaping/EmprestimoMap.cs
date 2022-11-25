using BibliotecaEmprestimos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaEmprestimos.Data.DataMaping
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimo");

            builder.HasKey("Id");
            builder.Property("Id").UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property("DataEprestimo").HasColumnName("DataEprestimo").HasColumnType("DATETIME")
                .IsRequired();

            builder.Property("DataDevolucao").HasColumnName("DataDevolucao").HasColumnType("DATETIME")
                .IsRequired();

            //relacionamentos 
            builder.HasOne(x => x.Leitor).WithMany(x => x.Emprestimos).HasForeignKey("LeitorId")
                .HasConstraintName("FK_Emprestimo_LeitorId");

            builder.HasMany(x => x.Livros).WithMany(x => x.Emprestimos).UsingEntity<Dictionary<string, object>>
                ("LivroEmprestimo", emprestimo => emprestimo.HasOne<Livro>().WithMany()
                    .HasForeignKey("LivroId").HasConstraintName("LivroId"),
                    livro => livro.HasOne<Emprestimo>().WithMany().HasForeignKey("EmprestimoId")
                    .HasConstraintName("FK_Emprestimo_Leitor_EmprestimoId")
                );
        }
    }
}