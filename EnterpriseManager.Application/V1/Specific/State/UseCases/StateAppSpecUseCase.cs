using EnterpriseManager.Application.V1.Specific.State.Objects;
using EnterpriseManager.Application.V1.Specific.State.Services;
using EnterpriseManager.Application.V1.Specific.State.Services.Validators;
using EnterpriseManager.Application.V1.Specific.State.UseCases;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.State.UseCases
{
	public class StateAppSpecUseCase : IStateAppSpecUseCase
	{
		private readonly ILogger<StateAppSpecUseCase> _iLogger;

		private IStateAppSpecServ _iStateAppSpecServ;

		public StateAppSpecUseCase(
			ILogger<StateAppSpecUseCase> iLogger,
			IStateAppSpecServ iStateAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iStateAppSpecServ = iStateAppSpecServ;
		}

		public async Task<StateAppSpecObje> GetStateByIdAsync(long id)
		{
			StateAppSpecServVali.ValidateTheInputsOfTheGetStateByIdAsyncMethod(id);

			StateAppSpecObje StateAppSpecObje = await _iStateAppSpecServ.GetStateByIdAsync(id);

			return StateAppSpecObje;
		}

		public async Task<IEnumerable<StateAppSpecObje>> GetStatesByAcronymOrName(string? acronymOrName)
		{
			IEnumerable<StateAppSpecObje> StateAppSpecObje = await _iStateAppSpecServ.GetStatesByAcronymOrName(acronymOrName);

			return StateAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateStateAsync(StateAppSpecObje? stateAppSpecObje)
		{
			StateAppSpecServVali.ValidateTheInputsOfTheInsertOrUpdateStateAsyncMethod(stateAppSpecObje);
			return await _iStateAppSpecServ.InsertOrUpdateStateAsync(stateAppSpecObje);
		}

		public async Task<bool> DeleteStateByIdAsync(long id)
		{
			StateAppSpecServVali.ValidateTheInputsOfTheDeleteStateByIdAsyncMethod(id);

			bool output = await _iStateAppSpecServ.DeleteStateByIdAsync(id);

			return output;
		}
	}
}