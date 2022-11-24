
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

            //relacionamentos
            builder.HasMany(x => x.Autores).WithMany(x => x.Livros).UsingEntity<Dictionary<string, object>>(
                "LivroAutor", livro => livro.HasOne<Autor>().WithMany().HasForeignKey("AutorId")
                .HasConstraintName("FK_Autor_Livro_AutorId"),
                autor => autor.HasOne<Livro>().WithMany().HasForeignKey("LivroId")
                .HasConstraintName("FK_Livro_Autor_LivroId")
            );

            builder.HasMany(x => x.Leitores).WithMany(x => x.Livros).UsingEntity<Dictionary<string, object>>(
                "LeitorLivro", livro => livro.HasOne<Leitor>().WithMany().HasForeignKey("LeitorId")
                    .HasConstraintName("FK_Leitor_Livro_LeitorId"),
                leitor => leitor.HasOne<Livro>().WithMany().HasForeignKey("Livroid")
                .HasConstraintName("FK_Leitor_Livro_LivroId")
            );
            builder.HasMany(x => x.Pagamentos).WithMany(x => x.Livros).UsingEntity<Dictionary<string, object>>(
                "PagamentoLivro", livro => livro.HasOne<Pagamento>().WithMany().HasForeignKey("PagamentoIs")
                .HasConstraintName("FK_Pagamento_Livro_PagamentoId"),
                pagamento => pagamento.HasOne<Livro>().WithMany().HasForeignKey("LivroId")
                .HasConstraintName("FK_Pagamento_Livro_LivroId")
            );


        }
    }
}