using Microsoft.EntityFrameworkCore;
using minimals_api.Domain.DTOs;
using minimals_api.Infrastructure.Db;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a configuração para a conexão da DBContext (no caso aqui MinimalsContext) com o Banco de Dados
builder.Services.AddDbContext<MinimalsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionSqlServer")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO login) =>
{
  if (login.Email == "adm@teste.com" && login.Password == "123456") return Results.Ok("Usuário logado com sucesso!");
  return Results.Unauthorized();
});

app.Run();
