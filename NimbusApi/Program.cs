using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NimbusApi.Connection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<NimbusApi.Repository.AlertaRepository>();
builder.Services.AddScoped<NimbusApi.Repository.BairroRepository>();
builder.Services.AddScoped<NimbusApi.Repository.CidadeRepository>();
builder.Services.AddScoped<NimbusApi.Repository.EnderecoRepository>();
builder.Services.AddScoped<NimbusApi.Repository.EstadoRepository>();
builder.Services.AddScoped<NimbusApi.Repository.GpEnderecoRepository>();
builder.Services.AddScoped<NimbusApi.Repository.LocalizacaoRepository>();
builder.Services.AddScoped<NimbusApi.Repository.PaisRepository>();
builder.Services.AddScoped<NimbusApi.Repository.UsuarioRepository>();
builder.Services.AddScoped<NimbusApi.Services.AlertaService>();
builder.Services.AddScoped<NimbusApi.Services.BairroService>();
builder.Services.AddScoped<NimbusApi.Services.CidadeService>();
builder.Services.AddScoped<NimbusApi.Services.EnderecoService>();
builder.Services.AddScoped<NimbusApi.Services.EstadoService>();
builder.Services.AddScoped<NimbusApi.Services.GpEnderecoService>();
builder.Services.AddScoped<NimbusApi.Services.LocalizacaoService>();
builder.Services.AddScoped<NimbusApi.Services.PaisService>();
builder.Services.AddScoped<NimbusApi.Services.UsuarioService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API REST de sistema de alertas de desastres meteorologico",
        Description = "Aplica��o destinada a pessoas que criarem contas para utilizar o aplicativo",
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
