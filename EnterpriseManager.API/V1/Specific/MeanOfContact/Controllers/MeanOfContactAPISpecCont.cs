using EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EnterpriseManager.API.V1.Specific.MeanOfContact.Controllers
{
	///<Summary>
	/// This controller handles all MeanOfContact-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("Mean Of Contact")]
	[SwaggerTag("This controller handles all Mean Of Contact-related API requests.")]
	public class MeanOfContactAPISpecCont : ControllerBase
	{
		private readonly ILogger<MeanOfContactAPISpecCont> _iLogger;

		private IMeanOfContactAppSpecUseCase _iMeanOfContactAppSpecUseCase;

		///<Summary>
		/// MeanOfContactAPISpecCont constructor.
		///</Summary>
		public MeanOfContactAPISpecCont(
			ILogger<MeanOfContactAPISpecCont> iLogger,
			IMeanOfContactAppSpecUseCase iMeanOfContactAppSpecUseCase
		)
		{
			_iLogger = iLogger;
			_iMeanOfContactAppSpecUseCase = iMeanOfContactAppSpecUseCase;
		}

		/// <summary>
		/// Get a MeanOfContact by Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>A MeanOfContact.</returns>
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
		[EndpointSummary("It returns a MeanOfContact.")]
		[EndpointDescription("It returns a MeanOfContact by Id.")]
		public JsonResult Get(long id)
		{
			MeanOfContactAppSpecObje MeanOfContactAppSpecObje = _iMeanOfContactAppSpecUseCase.Get(id);

			return new JsonResult(MeanOfContactAppSpecObje);
		}
	}
}