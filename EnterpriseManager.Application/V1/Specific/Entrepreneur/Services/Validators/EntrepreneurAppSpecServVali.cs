using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;
using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Application.V1.Specific.Entrepreneur.Services.Validators
{
	public class EntrepreneurAppSpecServVali
	{
		public static void ValidateTheInputsOfTheGetEntrepreneurByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}

		public static void ValidateTheInputsOfTheInsertOrUpdateEntrepreneurAsyncMethod(EntrepreneurAppSpecObje? entrepreneurAppSpecObje)
		{
			if (entrepreneurAppSpecObje == null)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(entrepreneurAppSpecObje)}] cannot be null!");

			if (entrepreneurAppSpecObje.Id < 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(entrepreneurAppSpecObje.Id)}] cannot be less than or equals to 0!");

			if (string.IsNullOrWhiteSpace(entrepreneurAppSpecObje.Name))
				throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(entrepreneurAppSpecObje.Name)}] cannot be null or empty or white space!");
		}

		public static void ValidateTheInputsOfTheDeleteEntrepreneurByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}
	}
}