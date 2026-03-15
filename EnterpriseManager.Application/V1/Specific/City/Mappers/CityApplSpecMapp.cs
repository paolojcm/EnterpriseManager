using EnterpriseManager.Application.V1.Specific.City.Objects;
using EnterpriseManager.Domain.Specific.City.Entities;

namespace EnterpriseManager.Application.Specific.City.Mappers
{
	public class CityApplSpecMapp
	{
		public static CityAppSpecObje MapToApplicationObject(CityDomaSpecEnti? cityDomaSpecEnti)
		{
			CityAppSpecObje? cityAppSpecObje = null;

			if (cityDomaSpecEnti != null)
			{
				cityAppSpecObje = new CityAppSpecObje();
				cityAppSpecObje.Id = cityDomaSpecEnti.Id;
				cityAppSpecObje.Name = cityDomaSpecEnti.Name;
				cityAppSpecObje.StateId = cityDomaSpecEnti.StateId;
			}

			return cityAppSpecObje;
		}

		public static CityDomaSpecEnti MapToDomainEntity(CityAppSpecObje? cityAppSpecObje)
		{
			CityDomaSpecEnti? cityDomaSpecEnti = null;

			if (cityAppSpecObje != null)
			{
				cityDomaSpecEnti = new CityDomaSpecEnti();
				cityDomaSpecEnti.Id = cityAppSpecObje.Id;
				cityDomaSpecEnti.Name = cityAppSpecObje.Name;
				cityDomaSpecEnti.StateId = cityAppSpecObje.StateId;
			}

			return cityDomaSpecEnti;
		}
	}
}