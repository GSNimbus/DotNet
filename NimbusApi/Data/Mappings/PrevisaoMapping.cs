using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NimbusApi.Models;

namespace NimbusApi.Data.Mappings
{
    public class PrevisaoMapping : IEntityTypeConfiguration<Previsao>
    {
        public void Configure(EntityTypeBuilder<Previsao> builder)
        {
            builder.ToTable("t_nimbus_previsao");
            builder.HasKey(p => p.IdPrevisao);
            builder.Property(p => p.IdPrevisao)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_previsao");
            builder.Property(p => p.DataHora)
                .IsRequired()
                .HasColumnName("data_hora");
            builder.Property(p => p.Temperatura)
                .IsRequired()
                .HasColumnName("temperatura");
            builder.Property(p => p.Umidade)
                .IsRequired()
                .HasColumnName("umidade");
            builder.Property(p => p.Chuva)
                .IsRequired()
                .HasColumnName("chuva");
            builder.Property(p => p.CodigoChuva)
                .IsRequired()
                .HasColumnName("codigo_chuva");
            builder.Property(p => p.VelocidadeVento)
                .IsRequired()
                .HasColumnName("velocidade_vento");
            builder.Property(p => p.RajadaVento)
                .IsRequired()
                .HasColumnName("rajada_vento");
            builder.HasOne(a => a.Bairro)
               .WithMany(l => l.Previsao)
               .HasForeignKey(a => a.IdBairro);


        }
    }
}
