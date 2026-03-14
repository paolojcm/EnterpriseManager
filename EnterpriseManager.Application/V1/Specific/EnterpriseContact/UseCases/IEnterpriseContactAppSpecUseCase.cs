using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;

namespace EnterpriseManager.Application.V1.Specific.EnterpriseContact.UseCases
{
	public interface IEnterpriseContactAppSpecUseCase
	{
		EnterpriseContactAppSpecObje Get(long meanOfContactId, long enterpriseId);
	}
}