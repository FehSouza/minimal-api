using System.ComponentModel.DataAnnotations;

namespace minimals_api.Domain.Entities
{
	public class Administrator
	{
		public int Id { get; set; } = default!;

		[Required]
		[StringLength(255)]
		public string Email { get; set; } = default!;

		[StringLength(50)]
		public string Password { get; set; } = default!;

		[StringLength(10)]
		public string Profile { get; set; } = default!;
	}
}