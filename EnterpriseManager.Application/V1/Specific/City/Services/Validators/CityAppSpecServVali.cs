using EnterpriseManager.Application.V1.Specific.City.Objects;
using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Application.V1.Specific.City.Services.Validators
{
	public class CityAppSpecServVali
	{
		public static void ValidateTheInputsOfTheGetCityByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}

		public static void ValidateTheInputsOfTheInsertOrUpdateCityAsyncMethod(CityAppSpecObje? cityAppSpecObje)
		{
			if (cityAppSpecObje == null)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(cityAppSpecObje)}] cannot be null!");

			if (cityAppSpecObje.Id < 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(cityAppSpecObje.Id)}] cannot be less than or equals to 0!");

			if (string.IsNullOrWhiteSpace(cityAppSpecObje.Name))
				throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(cityAppSpecObje.Name)}] cannot be null or empty or white space!");

			if (cityAppSpecObje.StateId <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(cityAppSpecObje.StateId)}] cannot be less than or equals to 0!");
		}

		public static void ValidateTheInputsOfTheDeleteCityByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}
	}
}