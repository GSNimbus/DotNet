using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NimbusApi.Models;

namespace NimbusApi.Data.Mappings
{
    public class AlertaMapping : IEntityTypeConfiguration<Alerta>
    {
        public void Configure(EntityTypeBuilder<Alerta> builder)
        {
            builder.ToTable("t_nimbus_alerta");
            builder.HasKey(a => a.IdAlerta);
            builder.Property(a => a.Risco)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.Descricao)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(a => a.Mensagem)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(a => a.DataHora)
                .IsRequired();
            builder.HasOne(a => a.Bairro)
                .WithMany(l => l.Alertas)
                .HasForeignKey(a => a.IdBairro);
        }
    }
}
