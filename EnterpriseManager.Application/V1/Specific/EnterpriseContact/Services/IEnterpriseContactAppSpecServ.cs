using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;

namespace EnterpriseManager.Application.V1.Specific.EnterpriseContact.Services
{
	public interface IEnterpriseContactAppSpecServ
	{
		EnterpriseContactAppSpecObje Get(long meanOfContactId, long enterpriseId);
	}
}