using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NimbusApi.Models;

namespace NimbusApi.Data.Mappings
{
    public class BairroMapping : IEntityTypeConfiguration<Bairro>
    {
        public void Configure(EntityTypeBuilder<Bairro> builder)
        {
            builder.ToTable("t_nimbus_bairro");
            builder.HasKey(b => b.IdBairro);
            builder.Property(b => b.IdBairro)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_bairro");
            builder.Property(b => b.Logradouro)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasOne(b => b.Cidade)
                .WithMany()
                .HasForeignKey(b => b.IdCidade)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.Localizacao)
                .WithMany()
                .HasForeignKey(b => b.IdLocalizacao)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
