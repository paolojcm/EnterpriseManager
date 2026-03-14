using EnterpriseManager.Application.V1.Specific.OperatingSegment.Services;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects
{
	public class OperatingSegmentAppSpecServ : IOperatingSegmentAppSpecServ
	{
		private readonly ILogger<OperatingSegmentAppSpecServ> _iLogger;

		public OperatingSegmentAppSpecServ(ILogger<OperatingSegmentAppSpecServ> iLogger)
		{
			_iLogger = iLogger;
		}

		public OperatingSegmentAppSpecObje Get(long id)
		{
			OperatingSegmentAppSpecObje operatingSegmentAppSpecObje = new OperatingSegmentAppSpecObje();

			operatingSegmentAppSpecObje.Id = id;
			operatingSegmentAppSpecObje.Name = $"Name {id}";

			return operatingSegmentAppSpecObje;
		}
	}
}