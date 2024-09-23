using System.ComponentModel.DataAnnotations;

namespace minimals_api.Domain.Entities
{
	public class Vehicle
	{
		public int Id { get; set; } = default!;

		[Required]
		[StringLength(150)]
		public string Name { get; set; } = default!;

		[Required]
		[StringLength(100)]
		public string Brand { get; set; } = default!;

		[Required]
		public int Year { get; set; }
	}
}