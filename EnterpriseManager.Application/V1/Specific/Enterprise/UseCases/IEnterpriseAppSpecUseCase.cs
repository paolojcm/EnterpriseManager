using EnterpriseManager.Application.V1.Specific.Enterprise.Objects;

namespace EnterpriseManager.Application.V1.Specific.Enterprise.UseCases
{
	public interface IEnterpriseAppSpecUseCase
	{
		Task<EnterpriseAppSpecObje> GetEnterpriseByIdAsync(long id);

		Task<IEnumerable<EnterpriseAppSpecObje>> GetEnterprisesByNameAsync(string? name);

		Task<bool> InsertOrUpdateEnterpriseAsync(EnterpriseAppSpecObje? enterpriseAppSpecObje);

		Task<bool> DeleteEnterpriseByIdAsync(long id);
	}
}