using EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.Services
{
	public interface IOperatingSegmentAppSpecServ
	{
		Task<OperatingSegmentAppSpecObje> GetOperatingSegmentByIdAsync(long id);

		Task<IEnumerable<OperatingSegmentAppSpecObje>> GetOperatingSegmentsByNameAsync(string? name);

		Task<bool> InsertOrUpdateOperatingSegmentAsync(OperatingSegmentAppSpecObje? operatingSegmentAppSpecObje);

		Task<bool> DeleteOperatingSegmentByIdAsync(long id);
	}
}