using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using minimals_api.Domain.Entities;
using minimals_api.Domain.Interfaces;
using minimals_api.Infrastructure.Db;

namespace minimals_api.Domain.Services
{
	public class VehicleService(MinimalsContext context) : IVehicleService
	{
		private readonly MinimalsContext _context = context;

		private readonly int itemsPerPage = 10;

		public List<Vehicle> GetVehicle(int page = 1)
		{
			var vehicles = _context.Vehicles.AsQueryable();
			vehicles = vehicles.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
			return [.. vehicles];
		}

		public Vehicle? GetVehicleId(int id)
		{
			var vehicle = _context.Vehicles.Where(v => v.Id == id);
			return vehicle.FirstOrDefault();
		}

		public List<Vehicle> GetVehicleName(int page, string? name)
		{
			if (string.IsNullOrEmpty(name)) return [];
			var vehicles = _context.Vehicles.Where(v => v.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).AsQueryable();
			vehicles = vehicles.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
			return [.. vehicles];
		}

		public List<Vehicle> GetVehicleBrand(int page, string? brand)
		{
			if (string.IsNullOrEmpty(brand)) return [];
			var vehicles = _context.Vehicles.Where(v => v.Brand.Contains(brand, StringComparison.CurrentCultureIgnoreCase)).AsQueryable();
			vehicles = vehicles.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
			return [.. vehicles];
		}

		public void PostVehicle(Vehicle vehicle)
		{
			_context.Vehicles.Add(vehicle);
			_context.SaveChanges();
		}

		public void UpdateVehicle(Vehicle vehicle)
		{
			_context.Vehicles.Update(vehicle);
			_context.SaveChanges();
		}

		public void UpdateVehicleId(int id, Vehicle vehicle)
		{
			var vehicleFind = _context.Vehicles.Find(id);
			if (vehicleFind == null) return;
			_context.Vehicles.Update(vehicle);
			_context.SaveChanges();
		}

		public void DeleteVehicle(Vehicle vehicle)
		{
			_context.Vehicles.Remove(vehicle);
			_context.SaveChanges();
		}

		public void DeleteVehicleId(int id)
		{
			var vehicle = _context.Vehicles.Find(id);
			if (vehicle == null) return;
			_context.Vehicles.Remove(vehicle);
			_context.SaveChanges();

		}
	}
}