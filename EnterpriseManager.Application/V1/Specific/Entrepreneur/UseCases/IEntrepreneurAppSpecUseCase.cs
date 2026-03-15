using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;

namespace EnterpriseManager.Application.V1.Specific.Entrepreneur.UseCases
{
	public interface IEntrepreneurAppSpecUseCase
	{
		Task<EntrepreneurAppSpecObje> GetEntrepreneurByIdAsync(long id);

		Task<IEnumerable<EntrepreneurAppSpecObje>> GetEntrepreneursByNameAsync(string? name);

		Task<bool> InsertOrUpdateEntrepreneurAsync(EntrepreneurAppSpecObje? cityAppSpecObje);

		Task<bool> DeleteEntrepreneurByIdAsync(long id);
	}
}