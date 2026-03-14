using EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.Services
{
	public interface IOperatingSegmentAppSpecServ
	{
		OperatingSegmentAppSpecObje Get(long id);
	}
}