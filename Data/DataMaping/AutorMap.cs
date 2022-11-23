using BibliotecaEmprestimos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaEmprestimos.Data.DataMaping
{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");

            builder.HasKey("Id");
            builder.Property("Id").UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property("Nome").HasColumnName("Nome").HasColumnType("NVARCHAR").HasMaxLength(80)
                .IsRequired();
            builder.Property("DataNascimento").HasColumnName("DataNascimento").HasColumnType("DATETIME")
                .IsRequired();

        }
    }
}
