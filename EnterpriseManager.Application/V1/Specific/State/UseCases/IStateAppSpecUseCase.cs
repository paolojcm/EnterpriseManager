using EnterpriseManager.Application.V1.Specific.State.Objects;

namespace EnterpriseManager.Application.V1.Specific.State.UseCases
{
	public interface IStateAppSpecUseCase
	{
		StateAppSpecObje Get(long id);
	}
}