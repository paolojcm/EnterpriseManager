using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Services;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects
{
	public class EnterpriseContactAppSpecServ : IEnterpriseContactAppSpecServ
	{
		private readonly ILogger<EnterpriseContactAppSpecServ> _iLogger;

		public EnterpriseContactAppSpecServ(ILogger<EnterpriseContactAppSpecServ> iLogger)
		{
			_iLogger = iLogger;
		}

		public EnterpriseContactAppSpecObje Get(long meanOfContactId, long enterpriseId)
		{
			EnterpriseContactAppSpecObje EnterpriseContactAppSpecObje = new EnterpriseContactAppSpecObje();

			EnterpriseContactAppSpecObje.MeanOfContactId = meanOfContactId;
			EnterpriseContactAppSpecObje.EnterpriseId = enterpriseId;
			EnterpriseContactAppSpecObje.Contents = $"meanOfContactId {meanOfContactId} | enterpriseId {enterpriseId}";

			return EnterpriseContactAppSpecObje;
		}
	}
}