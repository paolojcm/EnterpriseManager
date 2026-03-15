using EnterpriseManager.Domain.Specific.OperatingSegment.Entities;

namespace EnterpriseManager.Domain.Specific.OperatingSegment.Repositories
{
	public interface IOperatingSegmentDomaSpecRepo
	{
		Task<OperatingSegmentDomaSpecEnti> GetOperatingSegmentByIdAsync(long id);

		Task<IEnumerable<OperatingSegmentDomaSpecEnti>> GetOperatingSegmentsByNameAsync(string? name);

		Task<bool> InsertOrUpdateOperatingSegmentAsync(OperatingSegmentDomaSpecEnti operatingSegmentDomaSpecEnti);

		Task<bool> DeleteOperatingSegmentByIdAsync(long id);
	}
}