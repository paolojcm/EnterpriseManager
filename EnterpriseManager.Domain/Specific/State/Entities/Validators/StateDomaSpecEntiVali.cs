using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Domain.Specific.State.Entities.Validators
{
	public class StateDomaSpecEntiVali
	{
		public static void CheckIfTheIfEntityExist(StateDomaSpecEnti? stateDomaSpecEnti)
		{
			if (stateDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.NotFound, $"State not found!");
		}

		public static void CheckIfTheEntitiesExist(IEnumerable<StateDomaSpecEnti>? citiesDomaSpecEnti)
		{
			if ((citiesDomaSpecEnti == null) || (citiesDomaSpecEnti.Count() == 0))
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Cities not found!");
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(IEnumerable<StateDomaSpecEnti>? oldCitiesDomaSpecEnti, StateDomaSpecEnti newStateDomaSpecEnti)
		{
			if ((oldCitiesDomaSpecEnti != null) && (oldCitiesDomaSpecEnti.Count() > 0))
			{
				if (newStateDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newStateDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newStateDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newStateDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (StateDomaSpecEnti stateDomaSpecEnti in oldCitiesDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(stateDomaSpecEnti.Name))
					{
						if (stateDomaSpecEnti.Name.Trim().ToLower() == newStateDomaSpecEnti.Name.Trim().ToLower())
						{
							if (stateDomaSpecEnti.Id != newStateDomaSpecEnti.Id)
							{
								throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a state with that name!");
							}
						}
					}
				}
			}
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeInsertingIt(IEnumerable<StateDomaSpecEnti>? oldCitiesDomaSpecEnti, StateDomaSpecEnti newStateDomaSpecEnti)
		{
			if ((oldCitiesDomaSpecEnti != null) && (oldCitiesDomaSpecEnti.Count() > 0))
			{
				if (newStateDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newStateDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newStateDomaSpecEnti.Acronym))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newStateDomaSpecEnti.Acronym)}] cannot be null or empty or white space!");

				if (string.IsNullOrWhiteSpace(newStateDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newStateDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (StateDomaSpecEnti stateDomaSpecEnti in oldCitiesDomaSpecEnti)
				{
					if (
							(!string.IsNullOrWhiteSpace(stateDomaSpecEnti.Acronym))
						&&
							(!string.IsNullOrWhiteSpace(stateDomaSpecEnti.Name))
					)
					{
						if (
							(stateDomaSpecEnti.Acronym.Trim().ToLower() == newStateDomaSpecEnti.Acronym.Trim().ToLower())
							||
							(stateDomaSpecEnti.Name.Trim().ToLower() == newStateDomaSpecEnti.Name.Trim().ToLower())
						)
						{
							throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a state with that name!");
						}
					}
				}
			}
		}
	}
}