using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;

namespace EnterpriseManager.Application.V1.Specific.EnterpriseContact.Services
{
	public interface IEnterpriseContactAppSpecServ
	{
		Task<EnterpriseContactAppSpecObje> GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId);

		Task<IEnumerable<EnterpriseContactAppSpecObje>> GetEnterpriseContactsByEnterpriseIdAsync(long enterpriseId);

		Task<bool> InsertOrUpdateEnterpriseContactAsync(EnterpriseContactAppSpecObje? enterpriseContactAppSpecObje);

		Task<bool> DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId);
	}
}