using minimals_api.Domain.DTOs;
using minimals_api.Domain.Entities;

namespace minimals_api.Domain.Interfaces
{
	public interface IAdministratorService
	{
		Administrator? Login(LoginDTO loginDTO);

		void PostAdministrator(Administrator administrator);

		List<Administrator> GetAdministrators(int? page);

		Administrator? GetAdministratorId(int id);

		void DeleteAdministrator(Administrator administrator);
	}
}