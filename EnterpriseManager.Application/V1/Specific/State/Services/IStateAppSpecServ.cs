using EnterpriseManager.Application.V1.Specific.State.Objects;

namespace EnterpriseManager.Application.V1.Specific.State.Services
{
	public interface IStateAppSpecServ
	{
		Task<StateAppSpecObje> GetStateByIdAsync(long id);

		Task<IEnumerable<StateAppSpecObje>> GetStatesByAcronymOrName(string? acronymOrName);

		Task<bool> InsertOrUpdateStateAsync(StateAppSpecObje? cityAppSpecObje);

		Task<bool> DeleteStateByIdAsync(long id);
	}
}