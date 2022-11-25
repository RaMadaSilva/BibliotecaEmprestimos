using BibliotecaEmprestimos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaEmprestimos.Data.DataMaping
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento");
            builder.HasKey("Id");
            builder.Property("Id").HasColumnName("Id").ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property("Montante").HasColumnName("Montante").HasColumnType("FLOAT")
                 .IsRequired();

            //relacionamento
            builder.HasOne(x => x.Emprestimo).WithOne().HasForeignKey<Pagamento>("EmprestimoId")
                .HasConstraintName("FK_Pagamento_Emprestimo_EmprestimoId");
        }
    }
}