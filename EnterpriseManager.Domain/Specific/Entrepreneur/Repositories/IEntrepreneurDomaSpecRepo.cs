using EnterpriseManager.Domain.Specific.Entrepreneur.Entities;

namespace EnterpriseManager.Domain.Specific.Entrepreneur.Repositories
{
	public interface IEntrepreneurDomaSpecRepo
	{
		Task<EntrepreneurDomaSpecEnti> GetEntrepreneurByIdAsync(long id);

		Task<IEnumerable<EntrepreneurDomaSpecEnti>> GetEntrepreneursByNameAsync(string? name);

		Task<bool> InsertOrUpdateEntrepreneurAsync(EntrepreneurDomaSpecEnti entrepreneurDomaSpecEnti);

		Task<bool> DeleteEntrepreneurByIdAsync(long id);
	}
}