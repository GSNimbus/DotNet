using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NimbusApi.Models;

namespace NimbusApi.Data.Mappings
{
    public class LocalizacaoMapping : IEntityTypeConfiguration<Localizacao>
    {
        public void Configure(EntityTypeBuilder<Localizacao> builder)
        {
            builder.ToTable("t_nimbus_localizacao");
            builder.HasKey(l => l.IdLocalizacao);
            builder.Property(l => l.IdLocalizacao)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_localizacao");
            builder.Property(l => l.Longitude)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(l => l.Latitude)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
