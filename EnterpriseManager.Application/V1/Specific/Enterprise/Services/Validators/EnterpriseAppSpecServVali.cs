using EnterpriseManager.Application.V1.Specific.Enterprise.Objects;
using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Application.V1.Specific.Enterprise.Services.Validators
{
	public class EnterpriseAppSpecServVali
	{
		public static void ValidateTheInputsOfTheGetEnterpriseByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}

		public static void ValidateTheInputsOfTheInsertOrUpdateEnterpriseAsyncMethod(EnterpriseAppSpecObje? enterpriseAppSpecObje)
		{
			if (enterpriseAppSpecObje == null)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseAppSpecObje)}] cannot be null!");

			if (enterpriseAppSpecObje.Id < 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseAppSpecObje.Id)}] cannot be less than or equals to 0!");

			if (string.IsNullOrWhiteSpace(enterpriseAppSpecObje.Name))
				throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseAppSpecObje.Name)}] cannot be null or empty or white space!");
			
			if (enterpriseAppSpecObje.Status < 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseAppSpecObje.Status)}] cannot be less than or equals to 0!");

			if (enterpriseAppSpecObje.EntrepreneurId <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseAppSpecObje.EntrepreneurId)}] cannot be less than or equals to 0!");

			if (enterpriseAppSpecObje.OperatingSegmentId <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseAppSpecObje.OperatingSegmentId)}] cannot be less than or equals to 0!");

			if (enterpriseAppSpecObje.CityId <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseAppSpecObje.CityId)}] cannot be less than or equals to 0!");
		}

		public static void ValidateTheInputsOfTheDeleteEnterpriseByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}
	}
}