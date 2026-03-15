using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Domain.Specific.Country.Entities.Validators
{
	public class CountryDomaSpecEntiVali
	{
		public static void CheckIfTheIfEntityExist(CountryDomaSpecEnti? countryDomaSpecEnti)
		{
			if (countryDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Country not found!");
		}

		public static void CheckIfTheEntitiesExist(IEnumerable<CountryDomaSpecEnti>? countriesDomaSpecEnti)
		{
			if ((countriesDomaSpecEnti == null) || (countriesDomaSpecEnti.Count() == 0))
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Countries not found!");
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(IEnumerable<CountryDomaSpecEnti>? oldCountriesDomaSpecEnti, CountryDomaSpecEnti newCountryDomaSpecEnti)
		{
			if ((oldCountriesDomaSpecEnti != null) && (oldCountriesDomaSpecEnti.Count() > 0))
			{
				if (newCountryDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newCountryDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newCountryDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newCountryDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (CountryDomaSpecEnti countryDomaSpecEnti in oldCountriesDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(countryDomaSpecEnti.Name))
					{
						if (countryDomaSpecEnti.Name.Trim().ToLower() == newCountryDomaSpecEnti.Name.Trim().ToLower())
						{
							if (countryDomaSpecEnti.Id != newCountryDomaSpecEnti.Id)
							{
								throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a country with that name!");
							}
						}
					}
				}
			}
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeInsertingIt(IEnumerable<CountryDomaSpecEnti>? oldCountriesDomaSpecEnti, CountryDomaSpecEnti newCountryDomaSpecEnti)
		{
			if ((oldCountriesDomaSpecEnti != null) && (oldCountriesDomaSpecEnti.Count() > 0))
			{
				if (newCountryDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newCountryDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newCountryDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newCountryDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (CountryDomaSpecEnti countryDomaSpecEnti in oldCountriesDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(countryDomaSpecEnti.Name))
					{
						if (countryDomaSpecEnti.Name.Trim().ToLower() == newCountryDomaSpecEnti.Name.Trim().ToLower())
						{
							throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a country with that name!");
						}
					}
				}
			}
		}
	}
}