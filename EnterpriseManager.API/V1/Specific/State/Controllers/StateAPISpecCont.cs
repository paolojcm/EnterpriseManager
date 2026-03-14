using EnterpriseManager.Application.V1.Specific.State.Objects;
using EnterpriseManager.Application.V1.Specific.State.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EnterpriseManager.API.V1.Specific.State.Controllers
{
	///<Summary>
	/// This controller handles all State-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("State")]
	[SwaggerTag("This controller handles all State-related API requests.")]
	public class StateAPISpecCont : ControllerBase
	{
		private readonly ILogger<StateAPISpecCont> _iLogger;

		private IStateAppSpecUseCase _iStateAppSpecUseCase;

		///<Summary>
		/// StateAPISpecCont constructor.
		///</Summary>
		public StateAPISpecCont(
			ILogger<StateAPISpecCont> iLogger,
			IStateAppSpecUseCase iStateAppSpecUseCase
		)
		{
			_iLogger = iLogger;
			_iStateAppSpecUseCase = iStateAppSpecUseCase;
		}

		/// <summary>
		/// Get a State by Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>A State.</returns>
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
		[EndpointSummary("It returns a State.")]
		[EndpointDescription("It returns a State by Id.")]
		public JsonResult Get(long id)
		{
			StateAppSpecObje StateAppSpecObje = _iStateAppSpecUseCase.Get(id);

			return new JsonResult(StateAppSpecObje);
		}
	}
}