using ClientesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(c => c.DataHoraCadastro)
                .HasColumnName("DATAHORACADASTRO")
                .IsRequired();
                
        }
    }
}
