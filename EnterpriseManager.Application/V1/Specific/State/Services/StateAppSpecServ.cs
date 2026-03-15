using EnterpriseManager.Application.Specific.State.Mappers;
using EnterpriseManager.Application.V1.Specific.State.Services;
using EnterpriseManager.Domain.Specific.State.Entities;
using EnterpriseManager.Domain.Specific.State.Entities.Validators;
using EnterpriseManager.Domain.Specific.State.Repositories;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.State.Objects
{
	public class StateAppSpecServ : IStateAppSpecServ
	{
		private readonly ILogger<StateAppSpecServ> _iLogger;

		private IStateDomaSpecRepo _iStateDomaSpecRepo;

		public StateAppSpecServ(
			ILogger<StateAppSpecServ> iLogger,
			IStateDomaSpecRepo iStateDomaSpecRepo
		)
		{
			_iLogger = iLogger;
			_iStateDomaSpecRepo = iStateDomaSpecRepo;
		}

		public async Task<StateAppSpecObje> GetStateByIdAsync(long id)
		{
			StateDomaSpecEnti stateDomaSpecEnti = await _iStateDomaSpecRepo.GetStateByIdAsync(id);
			StateDomaSpecEntiVali.CheckIfTheIfEntityExist(stateDomaSpecEnti);
			StateAppSpecObje stateAppSpecObje = StateApplSpecMapp.MapToApplicationObject(stateDomaSpecEnti);
			return stateAppSpecObje;
		}

		public async Task<IEnumerable<StateAppSpecObje>> GetStatesByAcronymOrName(string? acronymOrName)
		{
			IEnumerable<StateDomaSpecEnti> statesDomaSpecEnti = await _iStateDomaSpecRepo.GetStatesByAcronymOrName(acronymOrName);
			StateDomaSpecEntiVali.CheckIfTheEntitiesExist(statesDomaSpecEnti);

			List<StateAppSpecObje> statesAppSpecObje = new List<StateAppSpecObje>();

			StateAppSpecObje? stateAppSpecObje = null;

			foreach (StateDomaSpecEnti stateDomaSpecEnti in statesDomaSpecEnti)
			{
				stateAppSpecObje = StateApplSpecMapp.MapToApplicationObject(stateDomaSpecEnti);
				statesAppSpecObje.Add(stateAppSpecObje);
			}

			return statesAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateStateAsync(StateAppSpecObje? stateAppSpecObje)
		{
			StateDomaSpecEnti newStateDomaSpecEnti = StateApplSpecMapp.MapToDomainEntity(stateAppSpecObje);

			IEnumerable<StateDomaSpecEnti>? oldStatesDomaSpecEnti = await _iStateDomaSpecRepo.GetStatesByAcronymOrName(newStateDomaSpecEnti.Acronym);
			if (
					(oldStatesDomaSpecEnti == null)
				||
					(oldStatesDomaSpecEnti.Count() == 0)
			)
			{
				oldStatesDomaSpecEnti = await _iStateDomaSpecRepo.GetStatesByAcronymOrName(newStateDomaSpecEnti.Name);
			}

			if (newStateDomaSpecEnti.Id > 0)
			{
				StateDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(oldStatesDomaSpecEnti, newStateDomaSpecEnti);
			}
			else
			{
				StateDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeInsertingIt(oldStatesDomaSpecEnti, newStateDomaSpecEnti);
			}

			return await _iStateDomaSpecRepo.InsertOrUpdateStateAsync(newStateDomaSpecEnti);
		}

		public async Task<bool> DeleteStateByIdAsync(long id)
		{
			bool output = await _iStateDomaSpecRepo.DeleteStateByIdAsync(id);
			return output;
		}
	}
}