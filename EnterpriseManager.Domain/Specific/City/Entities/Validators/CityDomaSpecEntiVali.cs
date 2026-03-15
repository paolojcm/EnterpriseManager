using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Domain.Specific.City.Entities.Validators
{
	public class CityDomaSpecEntiVali
	{
		public static void CheckIfTheIfEntityExist(CityDomaSpecEnti? cityDomaSpecEnti)
		{
			if (cityDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.NotFound, $"City not found!");
		}

		public static void CheckIfTheEntitiesExist(IEnumerable<CityDomaSpecEnti>? citiesDomaSpecEnti)
		{
			if ((citiesDomaSpecEnti == null) || (citiesDomaSpecEnti.Count() == 0))
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Cities not found!");
		}
		
		public static void CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(IEnumerable<CityDomaSpecEnti>? oldCitiesDomaSpecEnti, CityDomaSpecEnti newCityDomaSpecEnti)
		{
			if ((oldCitiesDomaSpecEnti != null) && (oldCitiesDomaSpecEnti.Count() > 0))
			{
				if (newCityDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newCityDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newCityDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newCityDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (CityDomaSpecEnti cityDomaSpecEnti in oldCitiesDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(cityDomaSpecEnti.Name))
					{
						if (cityDomaSpecEnti.Name.Trim().ToLower() == newCityDomaSpecEnti.Name.Trim().ToLower())
						{
							if (cityDomaSpecEnti.Id != newCityDomaSpecEnti.Id)
							{
								throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a city with that name!");
							}
						}
					}
				}
			}
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeInsertingIt(IEnumerable<CityDomaSpecEnti>? oldCitiesDomaSpecEnti, CityDomaSpecEnti newCityDomaSpecEnti)
		{
			if ((oldCitiesDomaSpecEnti != null) && (oldCitiesDomaSpecEnti.Count() > 0))
			{
				if (newCityDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newCityDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newCityDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newCityDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (CityDomaSpecEnti cityDomaSpecEnti in oldCitiesDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(cityDomaSpecEnti.Name))
					{
						if (cityDomaSpecEnti.Name.Trim().ToLower() == newCityDomaSpecEnti.Name.Trim().ToLower())
						{
							throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a city with that name!");
						}
					}
				}
			}
		}
	}
}