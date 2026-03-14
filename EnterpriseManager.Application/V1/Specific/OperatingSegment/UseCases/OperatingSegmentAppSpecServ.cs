using EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects;
using EnterpriseManager.Application.V1.Specific.OperatingSegment.Services;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases
{
	public class OperatingSegmentAppSpecUseCase : IOperatingSegmentAppSpecUseCase
	{
		private readonly ILogger<OperatingSegmentAppSpecUseCase> _iLogger;
		
		private IOperatingSegmentAppSpecServ _iOperatingSegmentAppSpecServ;

		public OperatingSegmentAppSpecUseCase(
			ILogger<OperatingSegmentAppSpecUseCase> iLogger,
			IOperatingSegmentAppSpecServ iOperatingSegmentAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iOperatingSegmentAppSpecServ = iOperatingSegmentAppSpecServ;
		}

		public OperatingSegmentAppSpecObje Get(long id)
		{
			OperatingSegmentAppSpecObje operatingSegmentAppSpecObje = _iOperatingSegmentAppSpecServ.Get(id);

			return operatingSegmentAppSpecObje;
		}
	}
}