using EnterpriseManager.Application.V1.Specific.City.Objects;
using EnterpriseManager.Application.V1.Specific.City.Services;
using EnterpriseManager.Application.V1.Specific.City.UseCases;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases
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

		public CityAppSpecObje Get(long id)
		{
			CityAppSpecObje CityAppSpecObje = _iCityAppSpecServ.Get(id);

			return CityAppSpecObje;
		}
	}
}