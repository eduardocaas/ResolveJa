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
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder
                .ToTable("Empresa")
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Url)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(e => e.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(e => e.Cnpj)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14)
                .IsRequired();

            builder
                .Property(e => e.Ramo)
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(e => e.Descricao)
                .HasColumnType("VARCHAR")
                .HasMaxLength(500)
                .IsRequired(false);

            builder
                .Property(e => e.DataAdmissao)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder
                .HasIndex(e => e.Url, "IX_Empresa_Url")
                .IsUnique();

            builder
                .HasIndex(e => e.Cnpj, "IX_Empresa_Cnpj")
                .IsUnique();
        }
    }
}
