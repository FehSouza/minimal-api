using minimals.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (Login login) =>
{
  if (login.Email == "adm@teste.com" && login.Password == "123456") return Results.Ok("Usuário logado com sucesso!");
  return Results.Unauthorized();
});

app.Run();
