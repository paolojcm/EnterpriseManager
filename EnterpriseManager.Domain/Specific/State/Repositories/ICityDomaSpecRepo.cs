using EnterpriseManager.Domain.Specific.State.Entities;

namespace EnterpriseManager.Domain.Specific.State.Repositories
{
	public interface IStateDomaSpecRepo
	{
		Task<StateDomaSpecEnti> GetStateByIdAsync(long id);

		Task<IEnumerable<StateDomaSpecEnti>> GetStatesByAcronymOrName(string? acronymOrName);

		Task<bool> InsertOrUpdateStateAsync(StateDomaSpecEnti stateDomaSpecEnti);

		Task<bool> DeleteStateByIdAsync(long id);
	}
}