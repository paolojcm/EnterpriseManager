using EnterpriseManager.Application.V1.Specific.City.Objects;

namespace EnterpriseManager.Application.V1.Specific.City.Services
{
	public interface ICityAppSpecServ
	{
		Task<CityAppSpecObje> GetCityByIdAsync(long id);
		
		Task<IEnumerable<CityAppSpecObje>> GetCitiesByNameAsync(string? name);

		Task<bool> InsertOrUpdateCityAsync(CityAppSpecObje? cityAppSpecObje);

		Task<bool> DeleteCityByIdAsync(long id);
	}
}