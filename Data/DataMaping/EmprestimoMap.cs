using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            builder.HasOne(x => x.Leitor).WithMany(x => x.Emprestimos).HasConstraintName("FK_Emprestimo_LeitorId")
                .HasForeignKey("LeitorId");

        }
    }
}