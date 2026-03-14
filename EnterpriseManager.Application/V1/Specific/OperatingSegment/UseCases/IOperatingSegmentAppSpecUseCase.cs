using EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases
{
	public interface IOperatingSegmentAppSpecUseCase
	{
		OperatingSegmentAppSpecObje Get(long id);
	}
}