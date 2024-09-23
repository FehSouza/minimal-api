using minimals_api.Domain.Entities;

namespace minimals_api.Domain.Interfaces
{
	public interface IVehicleService
	{
		List<Vehicle> GetVehicle(int? page);

		Vehicle? GetVehicleId(int id);

		List<Vehicle> GetVehicleName(int? page, string? name = null);

		List<Vehicle> GetVehicleBrand(int? page, string? brand = null);

		void PostVehicle(Vehicle vehicle);

		void UpdateVehicle(Vehicle vehicle);

		void DeleteVehicle(Vehicle vehicle);
	}
}