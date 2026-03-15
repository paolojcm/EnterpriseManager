using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Domain.Specific.City.Entities.Validators
{
	public class CityDomaSpecEntiVali
	{
		public static void ValidateIfEntityExists(CityDomaSpecEnti? cityDomaSpecEnti)
		{
			if (cityDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.NotFound, $"City not found!");
		}
	}
}
