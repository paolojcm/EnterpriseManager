using EnterpriseManager.Domain.Specific.Enterprise.Entities;

namespace EnterpriseManager.Domain.Specific.Enterprise.Repositories
{
	public interface IEnterpriseDomaSpecRepo
	{
		Task<EnterpriseDomaSpecEnti> GetEnterpriseByIdAsync(long id);

		Task<IEnumerable<EnterpriseDomaSpecEnti>> GetEnterprisesByNameAsync(string? name);

		Task<bool> InsertOrUpdateEnterpriseAsync(EnterpriseDomaSpecEnti enterpriseDomaSpecEnti);

		Task<bool> DeleteEnterpriseByIdAsync(long id);
	}
}