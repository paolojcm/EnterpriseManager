using EnterpriseManager.Application.V1.Specific.Country.Objects;
using EnterpriseManager.Application.V1.Specific.Country.Services;
using EnterpriseManager.Application.V1.Specific.Country.Services.Validators;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.Country.UseCases
{
	public class CountryAppSpecUseCase : ICountryAppSpecUseCase
	{
		private readonly ILogger<CountryAppSpecUseCase> _iLogger;

		private ICountryAppSpecServ _iCountryAppSpecServ;

		public CountryAppSpecUseCase(
			ILogger<CountryAppSpecUseCase> iLogger,
			ICountryAppSpecServ iCountryAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iCountryAppSpecServ = iCountryAppSpecServ;
		}

		public async Task<CountryAppSpecObje> GetCountryByIdAsync(long id)
		{
			CountryAppSpecServVali.ValidateTheInputsOfTheGetCountryByIdAsyncMethod(id);

			CountryAppSpecObje CountryAppSpecObje = await _iCountryAppSpecServ.GetCountryByIdAsync(id);

			return CountryAppSpecObje;
		}

		public async Task<IEnumerable<CountryAppSpecObje>> GetCountriesByNameAsync(string? name)
		{
			IEnumerable<CountryAppSpecObje> CountryAppSpecObje = await _iCountryAppSpecServ.GetCountriesByNameAsync(name);

			return CountryAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateCountryAsync(CountryAppSpecObje? countryAppSpecObje)
		{
			CountryAppSpecServVali.ValidateTheInputsOfTheInsertOrUpdateCountryAsyncMethod(countryAppSpecObje);
			return await _iCountryAppSpecServ.InsertOrUpdateCountryAsync(countryAppSpecObje);
		}

		public async Task<bool> DeleteCountryByIdAsync(long id)
		{
			CountryAppSpecServVali.ValidateTheInputsOfTheDeleteCountryByIdAsyncMethod(id);

			bool output = await _iCountryAppSpecServ.DeleteCountryByIdAsync(id);

			return output;
		}
	}
}