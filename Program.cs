using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimals_api.Domain.DTOs;
using minimals_api.Domain.Interfaces;
using minimals_api.Domain.Services;
using minimals_api.Infrastructure.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministratorService, AdministratorService>();

// Adiciona a configuração para a conexão da DBContext (no caso aqui MinimalsContext) com o Banco de Dados
builder.Services.AddDbContext<MinimalsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionSqlServer")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministratorService administratorService) =>
{
  if (administratorService.Login(loginDTO) != null) return Results.Ok("Usuário logado com sucesso!");
  return Results.Unauthorized();
});

app.Run();
