using EnterpriseManager.Application.V1.Specific.State.Objects;

namespace EnterpriseManager.Application.V1.Specific.State.UseCases
{
	public interface IStateAppSpecUseCase
	{
		Task<StateAppSpecObje> GetStateByIdAsync(long id);

		Task<IEnumerable<StateAppSpecObje>> GetStatesByAcronymOrName(string? acronymOrName);

		Task<bool> InsertOrUpdateStateAsync(StateAppSpecObje? stateAppSpecObje);

		Task<bool> DeleteStateByIdAsync(long id);
	}
}