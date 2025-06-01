using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NimbusApi.Models;

namespace NimbusApi.Data.Mappings
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("t_nimbus_cidade");
            builder.HasKey(c => c.IdCidade);
            builder.Property(c => c.IdCidade)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_cidade");
            builder.Property(c => c.NomeCidade)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasOne(c => c.Estado)
                .WithMany()
                .HasForeignKey(c => c.IdEstado)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
