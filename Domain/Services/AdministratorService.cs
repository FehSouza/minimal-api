using minimals_api.Domain.DTOs;
using minimals_api.Domain.Entities;
using minimals_api.Domain.Interfaces;
using minimals_api.Infrastructure.Db;

namespace minimals_api.Domain.Services
{
	public class AdministratorService(MinimalsContext context) : IAdministratorService
	{
		private readonly MinimalsContext _context = context;

		public Administrator? Login(LoginDTO loginDTO)
		{
			return _context.Administrators.Where(adm => adm.Email == loginDTO.Email && adm.Password == loginDTO.Password).FirstOrDefault();
		}
	}
}