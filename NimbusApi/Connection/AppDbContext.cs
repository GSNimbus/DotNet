using Microsoft.EntityFrameworkCore;
using NimbusApi.Data.Mappings;
using NimbusApi.Models;

namespace NimbusApi.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pais> Pais { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Localizacao> Localizacao { get; set; }
        public DbSet<GpEndereco> GpEnderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Previsao> Previsao { get; set; }
        public DbSet<Alerta> Alerta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaisMapping());
            modelBuilder.ApplyConfiguration(new EstadoMapping());
            modelBuilder.ApplyConfiguration(new CidadeMapping());
            modelBuilder.ApplyConfiguration(new LocalizacaoMapping());
            modelBuilder.ApplyConfiguration(new BairroMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new GpEnderecoMapping());
            modelBuilder.ApplyConfiguration(new AlertaMapping());
            modelBuilder.ApplyConfiguration(new PrevisaoMapping());
        }

    }
}
