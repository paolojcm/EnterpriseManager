using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;
using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Application.V1.Specific.EnterpriseContact.Services.Validators
{
	public class EnterpriseContactAppSpecServVali
	{
		public static void ValidateTheInputsOfTheGetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsyncMethod(long meanOfContactId, long enterpriseId)
		{
			if (meanOfContactId <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(meanOfContactId)}] cannot be less than or equals to 0!");

			if (enterpriseId <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseId)}] cannot be less than or equals to 0!");
		}

		public static void ValidateTheInputsOfTheInsertOrUpdateEnterpriseContactAsyncMethod(EnterpriseContactAppSpecObje? enterpriseContactAppSpecObje)
		{
			if (enterpriseContactAppSpecObje == null)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseContactAppSpecObje)}] cannot be null!");

			if (enterpriseContactAppSpecObje.MeanOfContactId < 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseContactAppSpecObje.MeanOfContactId)}] cannot be less than or equals to 0!");

			if (enterpriseContactAppSpecObje.EnterpriseId <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseContactAppSpecObje.EnterpriseId)}] cannot be less than or equals to 0!");
			
			if (string.IsNullOrWhiteSpace(enterpriseContactAppSpecObje.Contents))
				throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseContactAppSpecObje.Contents)}] cannot be null or empty or white space!");
		}

		public static void ValidateTheInputsOfTheDeleteEnterpriseContactByIdAsyncMethod(long meanOfContactId, long enterpriseId)
		{
			if (meanOfContactId <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(meanOfContactId)}] cannot be less than or equals to 0!");

			if (enterpriseId <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(enterpriseId)}] cannot be less than or equals to 0!");
		}
	}
}