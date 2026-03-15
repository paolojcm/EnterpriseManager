using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;

namespace EnterpriseManager.Application.V1.Specific.Entrepreneur.Services
{
	public interface IEntrepreneurAppSpecServ
	{
		Task<EntrepreneurAppSpecObje> GetEntrepreneurByIdAsync(long id);

		Task<IEnumerable<EntrepreneurAppSpecObje>> GetEntrepreneursByNameAsync(string? name);

		Task<bool> InsertOrUpdateEntrepreneurAsync(EntrepreneurAppSpecObje? entrepreneurAppSpecObje);

		Task<bool> DeleteEntrepreneurByIdAsync(long id);
	}
}