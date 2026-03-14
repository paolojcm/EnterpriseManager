using EnterpriseManager.Application.V1.Specific.State.Objects;

namespace EnterpriseManager.Application.V1.Specific.State.Services
{
	public interface IStateAppSpecServ
	{
		StateAppSpecObje Get(long id);
	}
}