using EnterpriseManager.Domain.Specific.MeanOfContact.Entities;

namespace EnterpriseManager.Domain.Specific.MeanOfContact.Repositories
{
	public interface IMeanOfContactDomaSpecRepo
	{
		Task<MeanOfContactDomaSpecEnti> GetMeanOfContactByIdAsync(long id);

		Task<IEnumerable<MeanOfContactDomaSpecEnti>> GetMeansOfContactByNameAsync(string? name);

		Task<bool> InsertOrUpdateMeanOfContactAsync(MeanOfContactDomaSpecEnti meanOfContactDomaSpecEnti);

		Task<bool> DeleteMeanOfContactByIdAsync(long id);
	}
}