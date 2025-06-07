using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NimbusApi.Connection;
using NimbusApi.Repository;
using NimbusApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<AlertaRepository>();
builder.Services.AddScoped<BairroRepository>();
builder.Services.AddScoped<CidadeRepository>();
builder.Services.AddScoped<EnderecoRepository>();
builder.Services.AddScoped<EstadoRepository>();
builder.Services.AddScoped<GpEnderecoRepository>();
builder.Services.AddScoped<LocalizacaoRepository>();
builder.Services.AddScoped<PaisRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PrevisaoRepository>();
builder.Services.AddScoped<AlertaService>();
builder.Services.AddScoped<BairroService>();
builder.Services.AddScoped<CidadeService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<EstadoService>();
builder.Services.AddScoped<GpEnderecoService>();
builder.Services.AddScoped<LocalizacaoService>();
builder.Services.AddScoped<PaisService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PrevisaoService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API REST de sistema de alertas de enchentes",
        Description = "Aplicação destinada a pessoas que criarem contas para utilizar o aplicativo",
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
