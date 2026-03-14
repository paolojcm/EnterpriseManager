using EnterpriseManager.Application.V1.Specific.City.Services;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.City.Objects
{
	public class CityAppSpecServ : ICityAppSpecServ
	{
		private readonly ILogger<CityAppSpecServ> _iLogger;

		public CityAppSpecServ(ILogger<CityAppSpecServ> iLogger)
		{
			_iLogger = iLogger;
		}

		public CityAppSpecObje Get(long id)
		{
			CityAppSpecObje CityAppSpecObje = new CityAppSpecObje();

			CityAppSpecObje.Id = id;
			CityAppSpecObje.Name = $"Name {id}";
			CityAppSpecObje.StateId = 1;

			return CityAppSpecObje;
		}
	}
}