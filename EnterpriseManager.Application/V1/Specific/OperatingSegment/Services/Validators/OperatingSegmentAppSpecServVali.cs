using EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects;
using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.Services.Validators
{
	public class OperatingSegmentAppSpecServVali
	{
		public static void ValidateTheInputsOfTheGetOperatingSegmentByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}

		public static void ValidateTheInputsOfTheInsertOrUpdateOperatingSegmentAsyncMethod(OperatingSegmentAppSpecObje? operatingSegmentAppSpecObje)
		{
			if (operatingSegmentAppSpecObje == null)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(operatingSegmentAppSpecObje)}] cannot be null!");

			if (operatingSegmentAppSpecObje.Id < 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(operatingSegmentAppSpecObje.Id)}] cannot be less than or equals to 0!");

			if (string.IsNullOrWhiteSpace(operatingSegmentAppSpecObje.Name))
				throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(operatingSegmentAppSpecObje.Name)}] cannot be null or empty or white space!");
		}

		public static void ValidateTheInputsOfTheDeleteOperatingSegmentByIdAsyncMethod(long id)
		{
			if (id <= 0)
				throw new ApplicationLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(id)}] cannot be less than or equals to 0!");
		}
	}
}