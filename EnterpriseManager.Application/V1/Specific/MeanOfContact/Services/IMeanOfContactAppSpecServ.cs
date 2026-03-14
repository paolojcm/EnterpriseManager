using EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects;

namespace EnterpriseManager.Application.V1.Specific.MeanOfContact.Services
{
	public interface IMeanOfContactAppSpecServ
	{
		MeanOfContactAppSpecObje Get(long id);
	}
}