using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;
using EnterpriseManager.Application.V1.Specific.EnterpriseContact.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EnterpriseManager.API.V1.Specific.EnterpriseContact.Controllers
{
	///<Summary>
	/// This controller handles all EnterpriseContact-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("Enterprise Contact")]
	[SwaggerTag("This controller handles all Enterprise Contact-related API requests.")]
	public class EnterpriseContactAPISpecCont : ControllerBase
	{
		private readonly ILogger<EnterpriseContactAPISpecCont> _iLogger;

		private IEnterpriseContactAppSpecUseCase _iEnterpriseContactAppSpecUseCase;

		///<Summary>
		/// EnterpriseContactAPISpecCont constructor.
		///</Summary>
		public EnterpriseContactAPISpecCont(
			ILogger<EnterpriseContactAPISpecCont> iLogger,
			IEnterpriseContactAppSpecUseCase iEnterpriseContactAppSpecUseCase
		)
		{
			_iLogger = iLogger;
			_iEnterpriseContactAppSpecUseCase = iEnterpriseContactAppSpecUseCase;
		}

		/// <summary>
		/// Get a EnterpriseContact by Id.
		/// </summary>
		/// <param name="meanOfContactId"></param>
		/// <param name="enterpriseId"></param>
		/// <returns>A EnterpriseContact.</returns>
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
		[EndpointSummary("It returns a EnterpriseContact.")]
		[EndpointDescription("It returns a EnterpriseContact by Id.")]
		public JsonResult Get(long meanOfContactId, long enterpriseId)
		{
			EnterpriseContactAppSpecObje EnterpriseContactAppSpecObje = _iEnterpriseContactAppSpecUseCase.Get(meanOfContactId, enterpriseId);

			return new JsonResult(EnterpriseContactAppSpecObje);
		}
	}
}