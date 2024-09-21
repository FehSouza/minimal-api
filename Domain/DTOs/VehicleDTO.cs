namespace minimals_api.Domain.DTOs
{
	public class VehicleDTO
	{
		public string Name { get; set; } = default!;

		public string Brand { get; set; } = default!;

		public int Year { get; set; }
	}
}