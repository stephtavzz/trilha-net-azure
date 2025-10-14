using Microsoft.EntityFrameworkCore;
using TrilhaNetAzureDesafio.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RHContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger only in development? here enabling always for convenience
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Rota raíz com mensagem de boas-vindas
app.MapGet("/", () =>
{
    return Results.Text("Bem-vindo(a) ao TrilhaNetAzureDesafio! Acesse a API em /swagger", "text/plain");
});

app.Run();
