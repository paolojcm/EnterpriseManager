using EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases
{
	public interface IOperatingSegmentAppSpecUseCase
	{
		Task<OperatingSegmentAppSpecObje> GetOperatingSegmentByIdAsync(long id);

		Task<IEnumerable<OperatingSegmentAppSpecObje>> GetOperatingSegmentsByNameAsync(string? name);

		Task<bool> InsertOrUpdateOperatingSegmentAsync(OperatingSegmentAppSpecObje? cityAppSpecObje);

		Task<bool> DeleteOperatingSegmentByIdAsync(long id);
	}
}