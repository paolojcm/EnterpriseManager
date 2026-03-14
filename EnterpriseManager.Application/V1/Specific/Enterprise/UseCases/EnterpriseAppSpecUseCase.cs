using EnterpriseManager.Application.V1.Specific.Enterprise.Objects;
using EnterpriseManager.Application.V1.Specific.Enterprise.Services;
using EnterpriseManager.Application.V1.Specific.Enterprise.UseCases;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases
{
	public class EnterpriseAppSpecUseCase : IEnterpriseAppSpecUseCase
	{
		private readonly ILogger<EnterpriseAppSpecUseCase> _iLogger;
		
		private IEnterpriseAppSpecServ _iEnterpriseAppSpecServ;

		public EnterpriseAppSpecUseCase(
			ILogger<EnterpriseAppSpecUseCase> iLogger,
			IEnterpriseAppSpecServ iEnterpriseAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iEnterpriseAppSpecServ = iEnterpriseAppSpecServ;
		}

		public EnterpriseAppSpecObje Get(long id)
		{
			EnterpriseAppSpecObje EnterpriseAppSpecObje = _iEnterpriseAppSpecServ.Get(id);

			return EnterpriseAppSpecObje;
		}
	}
}