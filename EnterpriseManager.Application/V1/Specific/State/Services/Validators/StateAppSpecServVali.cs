using EnterpriseManager.Application.V1.Specific.State.Objects;
using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Application.V1.Specific.State.Services.Validators
{
	public class StateAppSpecServVali
	{
		public static void ValidateTheInputsOfTheGetStateByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}

		public static void ValidateTheInputsOfTheInsertOrUpdateStateAsyncMethod(StateAppSpecObje? stateAppSpecObje)
		{
			if (stateAppSpecObje == null)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(stateAppSpecObje)}] cannot be null!");

			if (stateAppSpecObje.Id < 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(stateAppSpecObje.Id)}] cannot be less than or equals to 0!");

			if (string.IsNullOrWhiteSpace(stateAppSpecObje.Name))
				throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(stateAppSpecObje.Name)}] cannot be null or empty or white space!");
		}

		public static void ValidateTheInputsOfTheDeleteStateByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}
	}
}