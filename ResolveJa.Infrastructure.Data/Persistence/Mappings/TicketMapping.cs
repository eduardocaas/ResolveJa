using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResolveJa.Core.Entities;
using ResolveJa.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Infrastructure.Data.Persistence.Mappings
{
    public class TicketMapping : IEntityTypeConfiguration<Ticket>       
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .ToTable("Ticket")
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Titulo)
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(t => t.Cpf)
                .HasColumnType("VARCHAR")
                .HasMaxLength(11)
                .IsRequired();

            builder
                .Property(t => t.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(t => t.Status)
                .HasDefaultValue(TicketStatusEnum.ABERTO)
                .IsRequired(false);

            builder
                .Property(t => t.Conteudo)
                .HasColumnType("VARCHAR")
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .Property(t => t.Resposta)
                .HasColumnType("VARCHAR")
                .HasMaxLength(1000)
                .IsRequired(false);

            builder
                .Property(t => t.DataCriacao)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(false);

            builder
                .Property(t => t.DataFechamento)
                .HasColumnType("DATETIME")
                .IsRequired(false);
        }
    }
}
