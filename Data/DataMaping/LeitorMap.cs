using BibliotecaEmprestimos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaEmprestimos.Data.DataMaping
{
    public class LeitorMap : IEntityTypeConfiguration<Leitor>
    {
        public void Configure(EntityTypeBuilder<Leitor> builder)
        {
            builder.ToTable("Leitor");

            builder.HasKey("Id");
            builder.Property("Id").ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property("Nome").HasColumnName("Nome").HasColumnType("NVARCHAR").HasMaxLength(80)
                .IsRequired();
            builder.Property("DataNascimento").HasColumnName("DataNascimento").HasColumnType("DATETIME")
                .IsRequired();
            builder.Property("Telefone").HasColumnName("Telefone").HasColumnType("INT").HasMaxLength(9)
                .IsRequired();
            builder.Property("Email").HasColumnName("Email").HasColumnType("NVARCHAR").HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(x => x.Telefone, "IX_Leitor_Telefone").IsUnique();
            builder.HasIndex(x => x.Email, "IX_Leitor_Email").IsUnique();
        }
    }
}