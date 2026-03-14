using EnterpriseManager.Application.V1.Specific.Enterprise.Objects;

namespace EnterpriseManager.Application.V1.Specific.Enterprise.UseCases
{
	public interface IEnterpriseAppSpecUseCase
	{
		EnterpriseAppSpecObje Get(long id);
	}
}