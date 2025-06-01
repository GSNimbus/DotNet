using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NimbusApi.Models;

namespace NimbusApi.Data.Mappings
{
    public class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("t_nimbus_estado");
            builder.HasKey(e => e.IdEstado);
            builder.Property(e => e.IdEstado)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_estado");
            builder.Property(e => e.NomeEstado)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasOne(e => e.Pais)
                .WithMany()
                .HasForeignKey(p =>p.IdPais)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
