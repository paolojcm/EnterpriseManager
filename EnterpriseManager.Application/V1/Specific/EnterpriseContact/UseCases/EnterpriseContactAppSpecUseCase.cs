using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;
using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Services;
using EnterpriseManager.Application.V1.Specific.EnterpriseContact.UseCases;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases
{
	public class EnterpriseContactAppSpecUseCase : IEnterpriseContactAppSpecUseCase
	{
		private readonly ILogger<EnterpriseContactAppSpecUseCase> _iLogger;
		
		private IEnterpriseContactAppSpecServ _iEnterpriseContactAppSpecServ;

		public EnterpriseContactAppSpecUseCase(
			ILogger<EnterpriseContactAppSpecUseCase> iLogger,
			IEnterpriseContactAppSpecServ iEnterpriseContactAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iEnterpriseContactAppSpecServ = iEnterpriseContactAppSpecServ;
		}

		public EnterpriseContactAppSpecObje Get(long meanOfContactId, long enterpriseId)
		{
			EnterpriseContactAppSpecObje EnterpriseContactAppSpecObje = _iEnterpriseContactAppSpecServ.Get(meanOfContactId, enterpriseId);

			return EnterpriseContactAppSpecObje;
		}
	}
}