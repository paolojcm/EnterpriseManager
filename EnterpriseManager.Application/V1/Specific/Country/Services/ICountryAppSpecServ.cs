using EnterpriseManager.Application.V1.Specific.Country.Objects;

namespace EnterpriseManager.Application.V1.Specific.Country.Services
{
	public interface ICountryAppSpecServ
	{
		Task<CountryAppSpecObje> GetCountryByIdAsync(long id);

		Task<IEnumerable<CountryAppSpecObje>> GetCountriesByNameAsync(string? name);

		Task<bool> InsertOrUpdateCountryAsync(CountryAppSpecObje? countryAppSpecObje);

		Task<bool> DeleteCountryByIdAsync(long id);
	}
}