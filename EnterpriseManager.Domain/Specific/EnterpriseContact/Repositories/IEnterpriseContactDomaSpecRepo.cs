using EnterpriseManager.Domain.Specific.EnterpriseContact.Entities;

namespace EnterpriseManager.Domain.Specific.EnterpriseContact.Repositories
{
	public interface IEnterpriseContactDomaSpecRepo
	{
		Task<EnterpriseContactDomaSpecEnti> GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId);

		Task<IEnumerable<EnterpriseContactDomaSpecEnti>> GetEnterpriseContactsByEnterpriseIdAsync(long enterpriseId);

		Task<bool> InsertEnterpriseContactAsync(EnterpriseContactDomaSpecEnti enterpriseContactDomaSpecEnti);

		Task<bool> UpdateEnterpriseContactAsync(EnterpriseContactDomaSpecEnti enterpriseContactDomaSpecEnti);

		Task<bool> DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId);
	}
}