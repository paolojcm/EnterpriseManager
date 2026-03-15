using EnterpriseManager.Application.V1.Specific.State.Objects;
using EnterpriseManager.Domain.Specific.State.Entities;

namespace EnterpriseManager.Application.Specific.State.Mappers
{
	public class StateApplSpecMapp
	{
		public static StateAppSpecObje MapToApplicationObject(StateDomaSpecEnti? stateDomaSpecEnti)
		{
			StateAppSpecObje? stateAppSpecObje = null;

			if (stateDomaSpecEnti != null)
			{
				stateAppSpecObje = new StateAppSpecObje();
				stateAppSpecObje.Id = stateDomaSpecEnti.Id;
				stateAppSpecObje.Acronym = stateDomaSpecEnti.Acronym;
				stateAppSpecObje.Name = stateDomaSpecEnti.Name;
				stateAppSpecObje.CountryId = stateDomaSpecEnti.CountryId;
			}

			return stateAppSpecObje;
		}

		public static StateDomaSpecEnti MapToDomainEntity(StateAppSpecObje? stateAppSpecObje)
		{
			StateDomaSpecEnti? stateDomaSpecEnti = null;

			if (stateAppSpecObje != null)
			{
				stateDomaSpecEnti = new StateDomaSpecEnti();
				stateDomaSpecEnti.Id = stateAppSpecObje.Id;
				stateDomaSpecEnti.Acronym = stateAppSpecObje.Acronym;
				stateDomaSpecEnti.Name = stateAppSpecObje.Name;
				stateDomaSpecEnti.CountryId = stateAppSpecObje.CountryId;
			}

			return stateDomaSpecEnti;
		}
	}
}