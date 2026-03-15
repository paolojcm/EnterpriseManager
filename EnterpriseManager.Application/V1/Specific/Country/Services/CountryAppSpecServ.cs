using EnterpriseManager.Application.Specific.Country.Mappers;
using EnterpriseManager.Application.V1.Specific.Country.Services;
using EnterpriseManager.Domain.Specific.Country.Entities;
using EnterpriseManager.Domain.Specific.Country.Entities.Validators;
using EnterpriseManager.Domain.Specific.Country.Repositories;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.Country.Objects
{
	public class CountryAppSpecServ : ICountryAppSpecServ
	{
		private readonly ILogger<CountryAppSpecServ> _iLogger;

		private ICountryDomaSpecRepo _iCountryDomaSpecRepo;

		public CountryAppSpecServ(
			ILogger<CountryAppSpecServ> iLogger,
			ICountryDomaSpecRepo iCountryDomaSpecRepo
		)
		{
			_iLogger = iLogger;
			_iCountryDomaSpecRepo = iCountryDomaSpecRepo;
		}

		public async Task<CountryAppSpecObje> GetCountryByIdAsync(long id)
		{
			CountryDomaSpecEnti countryDomaSpecEnti = await _iCountryDomaSpecRepo.GetCountryByIdAsync(id);
			CountryDomaSpecEntiVali.CheckIfTheIfEntityExist(countryDomaSpecEnti);
			CountryAppSpecObje countryAppSpecObje = CountryApplSpecMapp.MapToApplicationObject(countryDomaSpecEnti);
			return countryAppSpecObje;
		}

		public async Task<IEnumerable<CountryAppSpecObje>> GetCountriesByNameAsync(string? name)
		{
			IEnumerable<CountryDomaSpecEnti> countriesDomaSpecEnti = await _iCountryDomaSpecRepo.GetCountriesByNameAsync(name);
			CountryDomaSpecEntiVali.CheckIfTheEntitiesExist(countriesDomaSpecEnti);

			List<CountryAppSpecObje> countriesAppSpecObje = new List<CountryAppSpecObje>();

			CountryAppSpecObje? countryAppSpecObje = null;

			foreach (CountryDomaSpecEnti countryDomaSpecEnti in countriesDomaSpecEnti)
			{
				countryAppSpecObje = CountryApplSpecMapp.MapToApplicationObject(countryDomaSpecEnti);
				countriesAppSpecObje.Add(countryAppSpecObje);
			}

			return countriesAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateCountryAsync(CountryAppSpecObje? countryAppSpecObje)
		{
			CountryDomaSpecEnti newCountryDomaSpecEnti = CountryApplSpecMapp.MapToDomainEntity(countryAppSpecObje);
			IEnumerable<CountryDomaSpecEnti>? oldCountriesDomaSpecEnti = await _iCountryDomaSpecRepo.GetCountriesByNameAsync(newCountryDomaSpecEnti.Name);
			if (newCountryDomaSpecEnti.Id > 0)
			{
				CountryDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(oldCountriesDomaSpecEnti, newCountryDomaSpecEnti);
			}
			else
			{
				CountryDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeInsertingIt(oldCountriesDomaSpecEnti, newCountryDomaSpecEnti);
			}

			return await _iCountryDomaSpecRepo.InsertOrUpdateCountryAsync(newCountryDomaSpecEnti);
		}

		public async Task<bool> DeleteCountryByIdAsync(long id)
		{
			bool output = await _iCountryDomaSpecRepo.DeleteCountryByIdAsync(id);
			return output;
		}
	}
}