using EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects;
using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Application.V1.Specific.MeanOfContact.Services.Validators
{
	public class MeanOfContactAppSpecServVali
	{
		public static void ValidateTheInputsOfTheGetMeanOfContactByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}

		public static void ValidateTheInputsOfTheInsertOrUpdateMeanOfContactAsyncMethod(MeanOfContactAppSpecObje? meanOfContactAppSpecObje)
		{
			if (meanOfContactAppSpecObje == null)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(meanOfContactAppSpecObje)}] cannot be null!");

			if (meanOfContactAppSpecObje.Id < 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(meanOfContactAppSpecObje.Id)}] cannot be less than or equals to 0!");

			if (string.IsNullOrWhiteSpace(meanOfContactAppSpecObje.Name))
				throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(meanOfContactAppSpecObje.Name)}] cannot be null or empty or white space!");
		}

		public static void ValidateTheInputsOfTheDeleteMeanOfContactByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}
	}
}