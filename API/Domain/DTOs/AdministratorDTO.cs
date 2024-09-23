using minimals_api.Domain.Entities;

namespace minimals_api.Domain.DTOs
{
	public class AdministratorDTO
	{
		public string Email { get; set; } = default!;
		public string Password { get; set; } = default!;
		public EnumProfile Profile { get; set; } = default!;
	}
}