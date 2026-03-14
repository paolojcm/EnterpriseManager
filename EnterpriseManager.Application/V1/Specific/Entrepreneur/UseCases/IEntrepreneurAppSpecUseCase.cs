using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;

namespace EnterpriseManager.Application.V1.Specific.Entrepreneur.UseCases
{
	public interface IEntrepreneurAppSpecUseCase
	{
		EntrepreneurAppSpecObje Get(long id);
	}
}