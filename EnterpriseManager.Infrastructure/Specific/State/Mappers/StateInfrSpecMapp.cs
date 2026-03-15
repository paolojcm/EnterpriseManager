using EnterpriseManager.Domain.Specific.State.Entities;
using EnterpriseManager.Infrastructure.Specific.State.Models;

namespace EnterpriseManager.Infrastructure.Specific.State.Mappers
{
	public class StateInfrSpecMapp
	{
		public static StateInfrSpecMode MapToPersistenceModel(StateDomaSpecEnti stateDomaSpecEnti)
		{
			StateInfrSpecMode? stateInfrSpecMode = null;

			if (stateDomaSpecEnti != null)
			{
				stateInfrSpecMode = new StateInfrSpecMode();
				stateInfrSpecMode.Id = stateDomaSpecEnti.Id;
				stateInfrSpecMode.Acronym = stateDomaSpecEnti.Acronym;
				stateInfrSpecMode.Name = stateDomaSpecEnti.Name;
				stateInfrSpecMode.CountryId = stateDomaSpecEnti.CountryId;
			}

			return stateInfrSpecMode;
		}

		public static StateDomaSpecEnti MapToDomainEntity(StateInfrSpecMode stateInfrSpecMode)
		{
			StateDomaSpecEnti? stateDomaSpecEnti = null;

			if (stateInfrSpecMode != null)
			{
				stateDomaSpecEnti = new StateDomaSpecEnti();
				stateDomaSpecEnti.Id = stateInfrSpecMode.Id;
				stateDomaSpecEnti.Acronym = stateInfrSpecMode.Acronym;
				stateDomaSpecEnti.Name = stateInfrSpecMode.Name;
				stateDomaSpecEnti.CountryId = stateInfrSpecMode.CountryId;
			}

			return stateDomaSpecEnti;
		}
	}
}