using EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects;

namespace EnterpriseManager.Application.V1.Specific.MeanOfContact.UseCases
{
	public interface IMeanOfContactAppSpecUseCase
	{
		MeanOfContactAppSpecObje Get(long id);
	}
}