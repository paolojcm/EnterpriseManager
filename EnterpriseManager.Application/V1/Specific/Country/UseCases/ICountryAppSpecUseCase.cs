using EnterpriseManager.Application.V1.Specific.Country.Objects;

namespace EnterpriseManager.Application.V1.Specific.Country.UseCases
{
	public interface ICountryAppSpecUseCase
	{
		CountryAppSpecObje Get(long id);
	}
}