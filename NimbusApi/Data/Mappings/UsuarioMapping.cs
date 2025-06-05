using Microsoft.EntityFrameworkCore;
using NimbusApi.Models;

namespace NimbusApi.Data.Mappings
{
    public class UsuarioMapping: IEntityTypeConfiguration<Usuario>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("t_nimbus_usuario");
            builder.HasKey(u => u.IdUsuario);
            builder.Property(u => u.IdUsuario)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_usuario");
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
