using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using minimals_api.Domain.DTOs;
using minimals_api.Domain.Entities;
using minimals_api.Domain.Interfaces;
using minimals_api.Domain.ModelViews;
using minimals_api.Domain.Services;
using minimals_api.Infrastructure.Db;

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona a configuração para a conexão da DBContext (no caso aqui MinimalsContext) com o Banco de Dados
builder.Services.AddDbContext<MinimalsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionSqlServer")));

var app = builder.Build();
#endregion

#region Home
// Instância da ModelView da Home
app.MapGet("/", () => Results.Json(new Home())).WithTags("Home");
#endregion

#region Administrators
app.MapPost("/administrators/login", ([FromBody] LoginDTO loginDTO, IAdministratorService administratorService) =>
{
  if (administratorService.Login(loginDTO) != null) return Results.Ok("Usuário logado com sucesso!");
  return Results.Unauthorized();
}).WithTags("Administrators");
#endregion

#region Vehicles
static ErrorVehicle ErrorVehicleValidation(VehicleDTO vehicleDTO)
{
  var error = new ErrorVehicle { Messages = [] };

  if (vehicleDTO.Name.IsNullOrEmpty()) error.Messages.Add("O nome não pode ser um dado vazio.");
  if (vehicleDTO.Brand.IsNullOrEmpty()) error.Messages.Add("A marca não pode ser um dado vazio.");
  if (vehicleDTO.Year < 1950) error.Messages.Add("Veículo muito antigo. A ano deve ser igual ou superior a 1950.");

  return error;
};


app.MapPost("/vehicles", ([FromBody] VehicleDTO vehicleDTO, IVehicleService vehicleService) =>
{
  var validation = ErrorVehicleValidation(vehicleDTO);
  if (validation.Messages.Count > 0) return Results.BadRequest(validation);

  var vehicle = new Vehicle
  {
    Name = vehicleDTO.Name,
    Brand = vehicleDTO.Brand,
    Year = vehicleDTO.Year
  };

  vehicleService.PostVehicle(vehicle);
  return Results.Created($"/vehicle/{vehicle.Id}", vehicle);
}).WithTags("Vehicles");

app.MapGet("/vehicles", ([FromQuery] int? page, IVehicleService vehicleService) =>
{
  var vehicles = vehicleService.GetVehicle(page);
  return Results.Ok(vehicles);
}).WithTags("Vehicles");

app.MapGet("/vehicle/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
  var vehicle = vehicleService.GetVehicleId(id);
  if (vehicle == null) return Results.NotFound();
  return Results.Ok(vehicle);
}).WithTags("Vehicles");

app.MapGet("/vehiclesName/{name}", ([FromRoute] string name, int? page, IVehicleService vehicleService) =>
{
  var vehicles = vehicleService.GetVehicleName(page, name);
  return Results.Ok(vehicles);
}).WithTags("Vehicles");

app.MapGet("/vehiclesBrand/{brand}", ([FromRoute] string brand, int? page, IVehicleService vehicleService) =>
{
  var vehicles = vehicleService.GetVehicleBrand(page, brand);
  return Results.Ok(vehicles);
}).WithTags("Vehicles");

app.MapPut("/vehicle/{id}", ([FromRoute] int id, VehicleDTO vehicleDTO, IVehicleService vehicleService) =>
{
  var vehicle = vehicleService.GetVehicleId(id);
  if (vehicle == null) return Results.NotFound();

  var validation = ErrorVehicleValidation(vehicleDTO);
  if (validation.Messages.Count > 0) return Results.BadRequest(validation);

  vehicle.Name = vehicleDTO.Name;
  vehicle.Brand = vehicleDTO.Brand;
  vehicle.Year = vehicleDTO.Year;

  vehicleService.UpdateVehicle(vehicle);
  return Results.Ok(vehicle);
}).WithTags("Vehicles");

app.MapDelete("/vehicle/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
  var vehicle = vehicleService.GetVehicleId(id);
  if (vehicle == null) return Results.NotFound();

  vehicleService.DeleteVehicle(vehicle);
  return Results.NoContent();
}).WithTags("Vehicles");
#endregion

#region App
// Configuração do Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
#endregion