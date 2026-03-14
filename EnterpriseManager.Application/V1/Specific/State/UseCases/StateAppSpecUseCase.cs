using EnterpriseManager.Application.V1.Specific.State.Objects;
using EnterpriseManager.Application.V1.Specific.State.Services;
using EnterpriseManager.Application.V1.Specific.State.UseCases;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases
{
	public class StateAppSpecUseCase : IStateAppSpecUseCase
	{
		private readonly ILogger<StateAppSpecUseCase> _iLogger;
		
		private IStateAppSpecServ _iStateAppSpecServ;

		public StateAppSpecUseCase(
			ILogger<StateAppSpecUseCase> iLogger,
			IStateAppSpecServ iStateAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iStateAppSpecServ = iStateAppSpecServ;
		}

		public StateAppSpecObje Get(long id)
		{
			StateAppSpecObje StateAppSpecObje = _iStateAppSpecServ.Get(id);

			return StateAppSpecObje;
		}
	}
}