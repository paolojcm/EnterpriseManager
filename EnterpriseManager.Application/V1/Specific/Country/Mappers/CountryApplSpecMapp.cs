using EnterpriseManager.Application.V1.Specific.Country.Objects;
using EnterpriseManager.Domain.Specific.Country.Entities;

namespace EnterpriseManager.Application.Specific.Country.Mappers
{
	public class CountryApplSpecMapp
	{
		public static CountryAppSpecObje MapToApplicationObject(CountryDomaSpecEnti? countryDomaSpecEnti)
		{
			CountryAppSpecObje? countryAppSpecObje = null;

			if (countryDomaSpecEnti != null)
			{
				countryAppSpecObje = new CountryAppSpecObje();
				countryAppSpecObje.Id = countryDomaSpecEnti.Id;
				countryAppSpecObje.Name = countryDomaSpecEnti.Name;
			}

			return countryAppSpecObje;
		}

		public static CountryDomaSpecEnti MapToDomainEntity(CountryAppSpecObje? countryAppSpecObje)
		{
			CountryDomaSpecEnti? countryDomaSpecEnti = null;

			if (countryAppSpecObje != null)
			{
				countryDomaSpecEnti = new CountryDomaSpecEnti();
				countryDomaSpecEnti.Id = countryAppSpecObje.Id;
				countryDomaSpecEnti.Name = countryAppSpecObje.Name;
			}

			return countryDomaSpecEnti;
		}
	}
}