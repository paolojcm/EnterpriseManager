using EnterpriseManager.Application.V1.Specific.City.Objects;

namespace EnterpriseManager.Application.V1.Specific.City.UseCases
{
	public interface ICityAppSpecUseCase
	{
		CityAppSpecObje Get(long id);
	}
}