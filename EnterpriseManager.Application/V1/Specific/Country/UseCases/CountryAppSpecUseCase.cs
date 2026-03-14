using EnterpriseManager.Application.V1.Specific.Country.Objects;
using EnterpriseManager.Application.V1.Specific.Country.Services;
using EnterpriseManager.Application.V1.Specific.Country.UseCases;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases
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

		public CountryAppSpecObje Get(long id)
		{
			CountryAppSpecObje CountryAppSpecObje = _iCountryAppSpecServ.Get(id);

			return CountryAppSpecObje;
		}
	}
}