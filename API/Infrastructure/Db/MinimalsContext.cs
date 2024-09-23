using Microsoft.EntityFrameworkCore;
using minimals_api.Domain.Entities;

namespace minimals_api.Infrastructure.Db
{
	public class MinimalsContext(DbContextOptions<MinimalsContext> options) : DbContext(options)
	{
		// O método OnModelCreating é chamado quando o BD está sendo configurado (criado ou atualizado), inserindo um registro padrão (ou seed data) na tabela
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Administrator>().HasData(
				new Administrator
				{
					// O Id foi definido como -1 para garantir que esse registro seed tenha um ID único e que não entre em conflito com registros futuros do BD
					Id = -1,
					Email = "admin@teste.com.br",
					Password = "123456",
					Profile = "Admin"
				}
			);
		}

		public DbSet<Administrator> Administrators { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
	}
}