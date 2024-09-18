using Microsoft.EntityFrameworkCore;
using minimals_api.Domain.Entities;

namespace minimals_api.Infrastructure.Db
{
	public class MinimalsContext(DbContextOptions<MinimalsContext> options) : DbContext(options)
	{
		public DbSet<Administrator> Administrators { get; set; }
	}
}