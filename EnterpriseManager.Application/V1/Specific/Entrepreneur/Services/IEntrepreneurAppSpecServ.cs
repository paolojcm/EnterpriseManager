using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;

namespace EnterpriseManager.Application.V1.Specific.Entrepreneur.Services
{
	public interface IEntrepreneurAppSpecServ
	{
		EntrepreneurAppSpecObje Get(long id);
	}
}