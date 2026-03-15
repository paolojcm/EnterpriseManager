using EnterpriseManager.Domain.Specific.City.Entities;
using EnterpriseManager.Infrastructure.Specific.City.Models;

namespace EnterpriseManager.Infrastructure.Specific.City.Mappers
{
	public class CityInfrSpecMapp
	{
		public static CityInfrSpecMode MapToPersistenceModel(CityDomaSpecEnti cityDomaSpecEnti)
		{
			CityInfrSpecMode? cityInfrSpecMode = null;

			if (cityDomaSpecEnti != null)
			{
				cityInfrSpecMode = new CityInfrSpecMode();
				cityInfrSpecMode.Id = cityDomaSpecEnti.Id;
				cityInfrSpecMode.Name = cityDomaSpecEnti.Name;
				cityInfrSpecMode.StateId = cityDomaSpecEnti.StateId;
			}

			return cityInfrSpecMode;
		}

		public static CityDomaSpecEnti MapToDomainEntity(CityInfrSpecMode cityInfrSpecMode)
		{
			CityDomaSpecEnti? cityDomaSpecEnti = null;

			if (cityInfrSpecMode != null)
			{
				cityDomaSpecEnti = new CityDomaSpecEnti();
				cityDomaSpecEnti.Id = cityInfrSpecMode.Id;
				cityDomaSpecEnti.Name = cityInfrSpecMode.Name;
				cityDomaSpecEnti.StateId = cityInfrSpecMode.StateId;
			}

			return cityDomaSpecEnti;
		}
	}
}