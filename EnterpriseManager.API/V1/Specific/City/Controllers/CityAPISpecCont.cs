using EnterpriseManager.Application.V1.Specific.City.Objects;
using EnterpriseManager.Application.V1.Specific.City.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EnterpriseManager.API.V1.Specific.City.Controllers
{
	///<Summary>
	/// This controller handles all City-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("City")]
	[SwaggerTag("This controller handles all City-related API requests.")]
	public class CityAPISpecCont : ControllerBase
	{
		private readonly ILogger<CityAPISpecCont> _iLogger;

		private ICityAppSpecUseCase _iCityAppSpecUseCase;

		///<Summary>
		/// CityAPISpecCont constructor.
		///</Summary>
		public CityAPISpecCont(
			ILogger<CityAPISpecCont> iLogger,
			ICityAppSpecUseCase iCityAppSpecUseCase
		)
		{
			_iLogger = iLogger;
			_iCityAppSpecUseCase = iCityAppSpecUseCase;
		}

		/// <summary>
		/// Get a City by Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>A City.</returns>
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
		[EndpointSummary("It returns a City.")]
		[EndpointDescription("It returns a City by Id.")]
		public JsonResult Get(long id)
		{
			CityAppSpecObje CityAppSpecObje = _iCityAppSpecUseCase.Get(id);

			return new JsonResult(CityAppSpecObje);
		}
	}
}