using EnterpriseManager.Domain.Specific.Country.Entities;
using EnterpriseManager.Infrastructure.Specific.Country.Models;

namespace EnterpriseManager.Infrastructure.Specific.Country.Mappers
{
	public class CountryInfrSpecMapp
	{
		public static CountryInfrSpecMode MapToPersistenceModel(CountryDomaSpecEnti countryDomaSpecEnti)
		{
			CountryInfrSpecMode? countryInfrSpecMode = null;

			if (countryDomaSpecEnti != null)
			{
				countryInfrSpecMode = new CountryInfrSpecMode();
				countryInfrSpecMode.Id = countryDomaSpecEnti.Id;
				countryInfrSpecMode.Name = countryDomaSpecEnti.Name;
			}

			return countryInfrSpecMode;
		}

		public static CountryDomaSpecEnti MapToDomainEntity(CountryInfrSpecMode countryInfrSpecMode)
		{
			CountryDomaSpecEnti? countryDomaSpecEnti = null;

			if (countryInfrSpecMode != null)
			{
				countryDomaSpecEnti = new CountryDomaSpecEnti();
				countryDomaSpecEnti.Id = countryInfrSpecMode.Id;
				countryDomaSpecEnti.Name = countryInfrSpecMode.Name;
			}

			return countryDomaSpecEnti;
		}
	}
}