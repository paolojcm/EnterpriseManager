using EnterpriseManager.Application.V1.Specific.City.Objects;

namespace EnterpriseManager.Application.V1.Specific.City.Services
{
	public interface ICityAppSpecServ
	{
		CityAppSpecObje Get(long id);
	}
}