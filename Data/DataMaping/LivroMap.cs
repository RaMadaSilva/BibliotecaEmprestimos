
using BibliotecaEmprestimos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaEmprestimos.Data.DataMaping
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey("Id");
            builder.Property("Id").UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property("Titulo").HasColumnName("Titulo").HasColumnType("NVARCHAR").HasMaxLength(300)
                .IsRequired();
            builder.Property("Genero").HasColumnName("Genero").HasColumnType("INT").HasMaxLength(2)
                .IsRequired();
            builder.Property("AnoEdicao").HasColumnName("AnoEdicao").HasColumnType("INT").HasMaxLength(4)
                .IsRequired();
            builder.Property("NumeroPag").HasColumnName("NumeroPag").HasColumnType("INT").HasMaxLength(5)
                .IsRequired();
            builder.Property("QuandidadeDisponivel").HasColumnName("QuandidadeDisponivel").HasColumnType("INT")
                .IsRequired().HasDefaultValue(1);
            builder.Property("PrecoUnidade").HasColumnName("PrecoUnidade").HasColumnType("FLOAT")
                .IsRequired();


        }
    }
}