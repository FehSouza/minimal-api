using minimals_api.Domain.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO login) =>
{
  if (login.Email == "adm@teste.com" && login.Password == "123456") return Results.Ok("Usuário logado com sucesso!");
  return Results.Unauthorized();
});

app.Run();
