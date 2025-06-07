using Microsoft.EntityFrameworkCore;
using NimbusApi.Models;

namespace NimbusApi.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("t_nimbus_endereco");
            builder.HasKey(e => e.IdEndereco);
            builder.Property(e => e.IdEndereco)
                .HasColumnName("id_endereco")
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Cep)
                .HasColumnName("cep")
                .IsRequired()
                .HasMaxLength(10);
            builder.HasOne(e => e.Bairro)
                .WithMany(b => b.Enderecos)
                .HasForeignKey(e => e.IdBairro);
        }

    }
}
