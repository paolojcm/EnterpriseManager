using EnterpriseManager.Application.V1.Specific.Enterprise.Objects;
using EnterpriseManager.Application.V1.Specific.Enterprise.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EnterpriseManager.API.V1.Specific.Enterprise.Controllers
{
	///<Summary>
	/// This controller handles all Enterprise-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("Enterprise")]
	[SwaggerTag("This controller handles all Enterprise-related API requests.")]
	public class EnterpriseAPISpecCont : ControllerBase
	{
		private readonly ILogger<EnterpriseAPISpecCont> _iLogger;

		private IEnterpriseAppSpecUseCase _iEnterpriseAppSpecUseCase;

		///<Summary>
		/// EnterpriseAPISpecCont constructor.
		///</Summary>
		public EnterpriseAPISpecCont(
			ILogger<EnterpriseAPISpecCont> iLogger,
			IEnterpriseAppSpecUseCase iEnterpriseAppSpecUseCase
		)
		{
			_iLogger = iLogger;
			_iEnterpriseAppSpecUseCase = iEnterpriseAppSpecUseCase;
		}

		/// <summary>
		/// Get a Enterprise by Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>A Enterprise.</returns>
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
		[EndpointSummary("It returns a Enterprise.")]
		[EndpointDescription("It returns a Enterprise by Id.")]
		public JsonResult Get(long id)
		{
			EnterpriseAppSpecObje EnterpriseAppSpecObje = _iEnterpriseAppSpecUseCase.Get(id);

			return new JsonResult(EnterpriseAppSpecObje);
		}
	}
}