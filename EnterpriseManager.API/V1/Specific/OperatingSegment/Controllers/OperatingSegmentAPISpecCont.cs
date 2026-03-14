using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EnterpriseManager.API.V1.Specific.Enterprise.Controllers
{
	///<Summary>
	/// This controller handles all Operating Segment-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("OperatingSegment")]
	[SwaggerTag("This controller handles all Operating Segment-related API requests.")]
	public class OperatingSegmentAPISpecCont : ControllerBase
	{
		private readonly ILogger<OperatingSegmentAPISpecCont> _iLogger;

		///<Summary>
		/// OperatingSegmentAPISpecCont constructor.
		///</Summary>
		public OperatingSegmentAPISpecCont(ILogger<OperatingSegmentAPISpecCont> iLogger)
		{
			_iLogger = iLogger;
		}

		/// <summary>
		/// Get an Operation Segment by Id.
		/// </summary>
		/// <param name="item"></param>
		/// <returns>A newly created TodoItem</returns>
		/// <remarks>
		/// Sample reponse:
		///
		///     {
		///        "id": 1,
		///        "name": "Item XXX",
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
			string output = @"
				{
					""id"": 1,
					""name"": ""Item XXX"",
				}
			";

			return new JsonResult(output);
		}
	}
}
