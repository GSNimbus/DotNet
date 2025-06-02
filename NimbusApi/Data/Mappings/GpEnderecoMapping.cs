using Microsoft.EntityFrameworkCore;
using NimbusApi.Models;

namespace NimbusApi.Data.Mappings
{
    public class GpEnderecoMapping : IEntityTypeConfiguration<GpEndereco>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<GpEndereco> builder)
        {
            builder.ToTable("t_nimbus_gp_endereco");
            builder.HasKey(g => g.IdGpEndereco);
            builder.Property(g => g.IdGpEndereco)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_gp_endereco");
            builder.Property(g => g.NmGrupo)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasOne(g => g.Usuario)
                .WithMany()
                .HasForeignKey(g => g.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(g => g.Endereco)
                .WithMany()
                .HasForeignKey(g => g.IdEndereco)
                .OnDelete(DeleteBehavior.Cascade);
        }
    } 
}
