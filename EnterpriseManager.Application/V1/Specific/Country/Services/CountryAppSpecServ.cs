using EnterpriseManager.Application.V1.Specific.Country.Services;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.Country.Objects
{
	public class CountryAppSpecServ : ICountryAppSpecServ
	{
		private readonly ILogger<CountryAppSpecServ> _iLogger;

		public CountryAppSpecServ(ILogger<CountryAppSpecServ> iLogger)
		{
			_iLogger = iLogger;
		}

		public CountryAppSpecObje Get(long id)
		{
			CountryAppSpecObje CountryAppSpecObje = new CountryAppSpecObje();

			CountryAppSpecObje.Id = id;
			CountryAppSpecObje.Name = $"Name {id}";

			return CountryAppSpecObje;
		}
	}
}