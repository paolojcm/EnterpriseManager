using EnterpriseManager.Application.V1.Specific.City.Objects;
using EnterpriseManager.Application.V1.Specific.City.Services;
using EnterpriseManager.Application.V1.Specific.City.Services.Validators;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.City.UseCases
{
	public class CityAppSpecUseCase : ICityAppSpecUseCase
	{
		private readonly ILogger<CityAppSpecUseCase> _iLogger;
		
		private ICityAppSpecServ _iCityAppSpecServ;

		public CityAppSpecUseCase(
			ILogger<CityAppSpecUseCase> iLogger,
			ICityAppSpecServ iCityAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iCityAppSpecServ = iCityAppSpecServ;
		}

		public async Task<CityAppSpecObje> GetCityByIdAsync(long id)
		{
			CityAppSpecServVali.ValidateTheInputsOfTheGetCityByIdAsyncMethod(id);

			CityAppSpecObje CityAppSpecObje = await _iCityAppSpecServ.GetCityByIdAsync(id);

			return CityAppSpecObje;
		}

		public async Task<IEnumerable<CityAppSpecObje>> GetCitiesByNameAsync(string? name)
		{
			IEnumerable<CityAppSpecObje> CityAppSpecObje = await _iCityAppSpecServ.GetCitiesByNameAsync(name);

			return CityAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateCityAsync(CityAppSpecObje? cityAppSpecObje)
		{
			CityAppSpecServVali.ValidateTheInputsOfTheInsertOrUpdateCityAsyncMethod(cityAppSpecObje);
			return await _iCityAppSpecServ.InsertOrUpdateCityAsync(cityAppSpecObje);
		}

		public async Task<bool> DeleteCityByIdAsync(long id)
		{
			CityAppSpecServVali.ValidateTheInputsOfTheDeleteCityByIdAsyncMethod(id);

			bool output = await _iCityAppSpecServ.DeleteCityByIdAsync(id);

			return output;
		}
	}
}