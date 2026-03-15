using EnterpriseManager.Application.Specific.City.Mappers;
using EnterpriseManager.Application.V1.Specific.City.Services;
using EnterpriseManager.Domain.Specific.City.Entities;
using EnterpriseManager.Domain.Specific.City.Entities.Validators;
using EnterpriseManager.Domain.Specific.City.Repositories;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.City.Objects
{
	public class CityAppSpecServ : ICityAppSpecServ
	{
		private readonly ILogger<CityAppSpecServ> _iLogger;

		private ICityDomaSpecRepo _iCityDomaSpecRepo;

		public CityAppSpecServ(
			ILogger<CityAppSpecServ> iLogger,
			ICityDomaSpecRepo iCityDomaSpecRepo
		)
		{
			_iLogger = iLogger;
			_iCityDomaSpecRepo = iCityDomaSpecRepo;
		}

		public async Task<CityAppSpecObje> GetCityByIdAsync(long id)
		{
			CityDomaSpecEnti cityDomaSpecEnti = await _iCityDomaSpecRepo.GetCityByIdAsync(id);
			CityDomaSpecEntiVali.CheckIfTheIfEntityExist(cityDomaSpecEnti);
			CityAppSpecObje cityAppSpecObje = CityApplSpecMapp.MapToApplicationObject(cityDomaSpecEnti);
			return cityAppSpecObje;
		}

		public async Task<IEnumerable<CityAppSpecObje>> GetCitiesByNameAsync(string? name)
		{
			IEnumerable<CityDomaSpecEnti> citiesDomaSpecEnti = await _iCityDomaSpecRepo.GetCitiesByNameAsync(name);
			CityDomaSpecEntiVali.CheckIfTheEntitiesExist(citiesDomaSpecEnti);

			List<CityAppSpecObje> citiesAppSpecObje = new List<CityAppSpecObje>();

			CityAppSpecObje? cityAppSpecObje = null;

			foreach (CityDomaSpecEnti cityDomaSpecEnti in citiesDomaSpecEnti)
			{
				cityAppSpecObje = CityApplSpecMapp.MapToApplicationObject(cityDomaSpecEnti);
				citiesAppSpecObje.Add(cityAppSpecObje);
			}

			return citiesAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateCityAsync(CityAppSpecObje? cityAppSpecObje)
		{
			CityDomaSpecEnti newCityDomaSpecEnti = CityApplSpecMapp.MapToDomainEntity(cityAppSpecObje);
			IEnumerable<CityDomaSpecEnti>? oldCitiesDomaSpecEnti = await _iCityDomaSpecRepo.GetCitiesByNameAsync(newCityDomaSpecEnti.Name);
			if (newCityDomaSpecEnti.Id > 0)
			{
				CityDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(oldCitiesDomaSpecEnti, newCityDomaSpecEnti);
			}
			else
			{
				CityDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeInsertingIt(oldCitiesDomaSpecEnti, newCityDomaSpecEnti);
			}

			return await _iCityDomaSpecRepo.InsertOrUpdateCityAsync(newCityDomaSpecEnti);
		}

		public async Task<bool> DeleteCityByIdAsync(long id)
		{
			bool output = await _iCityDomaSpecRepo.DeleteCityByIdAsync(id);
			return output;
		}
	}
}