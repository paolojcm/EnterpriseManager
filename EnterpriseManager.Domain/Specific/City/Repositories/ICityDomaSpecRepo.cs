using EnterpriseManager.Domain.Specific.City.Entities;

namespace EnterpriseManager.Domain.Specific.City.Repositories
{
	public interface ICityDomaSpecRepo
	{
		Task<CityDomaSpecEnti> GetCityByIdAsync(long id);

		Task<IEnumerable<CityDomaSpecEnti>> GetCitiesByNameAsync(string? name);

		Task<bool> InsertOrUpdateCityAsync(CityDomaSpecEnti cityDomaSpecEnti);

		Task<bool> DeleteCityByIdAsync(long id);
	}
}