using EnterpriseManager.Domain.Specific.Country.Entities;

namespace EnterpriseManager.Domain.Specific.Country.Repositories
{
	public interface ICountryDomaSpecRepo
	{
		Task<CountryDomaSpecEnti> GetCountryByIdAsync(long id);

		Task<IEnumerable<CountryDomaSpecEnti>> GetCountriesByNameAsync(string? name);

		Task<bool> InsertOrUpdateCountryAsync(CountryDomaSpecEnti cityDomaSpecEnti);

		Task<bool> DeleteCountryByIdAsync(long id);
	}
}