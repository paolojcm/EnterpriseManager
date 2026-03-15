using EnterpriseManager.Application.V1.General;
using System.Net;

namespace EnterpriseManager.Application.V1.Specific.City.Services.Validators
{
	public class CityAppSpecServVali
	{
		public static void ValidateTheInputsOfTheGetMethod(long id)
		{
			if (id < 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}
	}
}
