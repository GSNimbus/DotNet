using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NimbusApi.Models;

namespace NimbusApi.Data.Mappings
{
    public class PaisMapping : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("t_nimbus_pais");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_pais");
            builder.Property(p => p.NomePais)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
    
}

