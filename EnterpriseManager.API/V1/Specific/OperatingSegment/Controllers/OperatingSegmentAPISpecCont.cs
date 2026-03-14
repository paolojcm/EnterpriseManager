using EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects;
using EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EnterpriseManager.API.V1.Specific.Enterprise.Controllers
{
	///<Summary>
	/// This controller handles all Operating Segment-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("Operating Segment")]
	[SwaggerTag("This controller handles all Operating Segment-related API requests.")]
	public class OperatingSegmentAPISpecCont : ControllerBase
	{
		private readonly ILogger<OperatingSegmentAPISpecCont> _iLogger;

		private IOperatingSegmentAppSpecUseCase _iOperatingSegmentAppSpecUseCase;

		///<Summary>
		/// OperatingSegmentAPISpecCont constructor.
		///</Summary>
		public OperatingSegmentAPISpecCont(
			ILogger<OperatingSegmentAPISpecCont> iLogger,
			IOperatingSegmentAppSpecUseCase iOperatingSegmentAppSpecUseCase
		)
		{
			_iLogger = iLogger;
			_iOperatingSegmentAppSpecUseCase = iOperatingSegmentAppSpecUseCase;
		}

		/// <summary>
		/// Get an Operation Segment by Id.
		/// </summary>
		/// <param name="item"></param>
		/// <returns>An Operation Segment.</returns>
		/// <remarks>
		/// Sample reponse:
		///
		///     {
		///        "id": 1,
		///        "name": "Item GetTheInformationAboutTheRequest",
		///     }
		///
		/// </remarks>
		/// <response code="201">If the item is found.</response>
		/// <response code="404">If the item is not found.</response>
		[HttpGet("get")]
		[EndpointSummary("It returns an Operation Segment.")]
		[EndpointDescription("It returns an Operation Segment by Id.")]
		public JsonResult Get(long id)
		{
			OperatingSegmentAppSpecObje operatingSegmentAppSpecObje = _iOperatingSegmentAppSpecUseCase.Get(id);

			return new JsonResult(operatingSegmentAppSpecObje);
		}
	}
}