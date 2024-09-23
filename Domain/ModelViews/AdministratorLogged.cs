namespace minimals_api.Domain.ModelViews
{
	public record AdministratorLogged
	{
		public string Email { get; set; } = default!;
		public string Profile { get; set; } = default!;
		public string Token { get; set; } = default!;
	}
}