using minimals_api.Domain.DTOs;
using minimals_api.Domain.Entities;
using minimals_api.Domain.Interfaces;
using minimals_api.Infrastructure.Db;

namespace minimals_api.Domain.Services
{
	public class AdministratorService(MinimalsContext context) : IAdministratorService
	{
		private readonly MinimalsContext _context = context;

		private readonly int itemsPerPage = 10;

		public Administrator? Login(LoginDTO loginDTO)
		{
			return _context.Administrators.Where(adm => adm.Email == loginDTO.Email && adm.Password == loginDTO.Password).FirstOrDefault();
		}

		public void PostAdministrator(Administrator administrator)
		{
			_context.Administrators.Add(administrator);
			_context.SaveChanges();
		}

		public List<Administrator> GetAdministrators(int? page)
		{
			var administrators = _context.Administrators.AsQueryable();

			var pageConvert = page == null ? 1 : Convert.ToInt32(page);
			administrators = administrators.Skip((pageConvert - 1) * itemsPerPage).Take(itemsPerPage);

			return [.. administrators];
		}

		public Administrator? GetAdministratorId(int id)
		{
			var administrator = _context.Administrators.Where(a => a.Id == id);
			return administrator.FirstOrDefault();
		}

		public void DeleteAdministrator(Administrator administrator)
		{
			_context.Administrators.Remove(administrator);
			_context.SaveChanges();
		}
	}
}