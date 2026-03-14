using EnterpriseManager.Application.V1.Specific.Enterprise.Objects;

namespace EnterpriseManager.Application.V1.Specific.Enterprise.Services
{
	public interface IEnterpriseAppSpecServ
	{
		EnterpriseAppSpecObje Get(long id);
	}
}