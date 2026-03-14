using EnterpriseManager.Application.V1.Specific.Country.Objects;
using EnterpriseManager.Application.V1.Specific.Country.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EnterpriseManager.API.V1.Specific.Enterprise.Controllers
{
	///<Summary>
	/// This controller handles all Country-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("Country")]
	[SwaggerTag("This controller handles all Country-related API requests.")]
	public class CountryAPISpecCont : ControllerBase
	{
		private readonly ILogger<CountryAPISpecCont> _iLogger;

		private ICountryAppSpecUseCase _iCountryAppSpecUseCase;

		///<Summary>
		/// CountryAPISpecCont constructor.
		///</Summary>
		public CountryAPISpecCont(
			ILogger<CountryAPISpecCont> iLogger,
			ICountryAppSpecUseCase iCountryAppSpecUseCase
		)
		{
			_iLogger = iLogger;
			_iCountryAppSpecUseCase = iCountryAppSpecUseCase;
		}

		/// <summary>
		/// Get a Country by Id.
		/// </summary>
		/// <param name="item"></param>
		/// <returns>A Country.</returns>
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
		[EndpointSummary("It returns a Country.")]
		[EndpointDescription("It returns a Country by Id.")]
		public JsonResult Get(long id)
		{
			CountryAppSpecObje CountryAppSpecObje = _iCountryAppSpecUseCase.Get(id);

			return new JsonResult(CountryAppSpecObje);
		}
	}
}