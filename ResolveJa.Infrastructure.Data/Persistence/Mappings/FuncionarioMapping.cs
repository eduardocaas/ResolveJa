using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResolveJa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Infrastructure.Data.Persistence.Mappings
{
    internal class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder
                .ToTable("Funcionario")
                .HasKey(f => f.Id);

            builder
                .Property(f => f.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(f => f.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(f => f.DataAdmissao)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(false);

            builder
                .HasIndex(f => f.Email, "IX_Funcionario_Email")
                .IsUnique();
        }
    }
}
