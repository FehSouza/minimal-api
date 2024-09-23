namespace minimals_api.Domain.ModelViews
{
	public record AdministratorMV
	{
		public int Id { get; set; } = default!;
		public string Email { get; set; } = default!;
		public string Profile { get; set; } = default!;
	}
}