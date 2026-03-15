using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;

namespace EnterpriseManager.Application.V1.Specific.EnterpriseContact.UseCases
{
	public interface IEnterpriseContactAppSpecUseCase
	{
		Task<EnterpriseContactAppSpecObje> GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId);

		Task<IEnumerable<EnterpriseContactAppSpecObje>> GetEnterpriseContactsByEnterpriseIdAsync(long enterpriseId);

		Task<bool> InsertOrUpdateEnterpriseContactAsync(EnterpriseContactAppSpecObje? enterpriseContactAppSpecObje);

		Task<bool> DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId);
	}
}