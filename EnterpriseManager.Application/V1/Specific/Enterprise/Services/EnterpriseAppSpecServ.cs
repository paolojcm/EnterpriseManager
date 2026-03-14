using EnterpriseManager.Application.V1.Specific.Enterprise.Services;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.Enterprise.Objects
{
	public class EnterpriseAppSpecServ : IEnterpriseAppSpecServ
	{
		private readonly ILogger<EnterpriseAppSpecServ> _iLogger;

		public EnterpriseAppSpecServ(ILogger<EnterpriseAppSpecServ> iLogger)
		{
			_iLogger = iLogger;
		}

		public EnterpriseAppSpecObje Get(long id)
		{
			EnterpriseAppSpecObje EnterpriseAppSpecObje = new EnterpriseAppSpecObje();

			EnterpriseAppSpecObje.Id = id;
			EnterpriseAppSpecObje.Name = $"Name {id}";
			EnterpriseAppSpecObje.Status = 1;
			EnterpriseAppSpecObje.EntrepreneurId = 1;
			EnterpriseAppSpecObje.OperatingSegmentId = 1;
			EnterpriseAppSpecObje.CityId = 1;

			return EnterpriseAppSpecObje;
		}
	}
}