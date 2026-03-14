using EnterpriseManager.Application.V1.Specific.Country.Objects;

namespace EnterpriseManager.Application.V1.Specific.Country.Services
{
	public interface ICountryAppSpecServ
	{
		CountryAppSpecObje Get(long id);
	}
}