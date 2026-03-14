using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;
using EnterpriseManager.Application.V1.Specific.Entrepreneur.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EnterpriseManager.API.V1.Specific.Entrepreneur.Controllers
{
	///<Summary>
	/// This controller handles all Entrepreneur-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("Entrepreneur")]
	[SwaggerTag("This controller handles all Entrepreneur-related API requests.")]
	public class EntrepreneurAPISpecCont : ControllerBase
	{
		private readonly ILogger<EntrepreneurAPISpecCont> _iLogger;

		private IEntrepreneurAppSpecUseCase _iEntrepreneurAppSpecUseCase;

		///<Summary>
		/// EntrepreneurAPISpecCont constructor.
		///</Summary>
		public EntrepreneurAPISpecCont(
			ILogger<EntrepreneurAPISpecCont> iLogger,
			IEntrepreneurAppSpecUseCase iEntrepreneurAppSpecUseCase
		)
		{
			_iLogger = iLogger;
			_iEntrepreneurAppSpecUseCase = iEntrepreneurAppSpecUseCase;
		}

		/// <summary>
		/// Get an Operation Segment by Id.
		/// </summary>
		/// <param name="id"></param>
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
			EntrepreneurAppSpecObje EntrepreneurAppSpecObje = _iEntrepreneurAppSpecUseCase.Get(id);

			return new JsonResult(EntrepreneurAppSpecObje);
		}
	}
}