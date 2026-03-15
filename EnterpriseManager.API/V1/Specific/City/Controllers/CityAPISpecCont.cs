using EnterpriseManager.Application.V1.General;
using EnterpriseManager.Application.V1.Specific.City.Objects;
using EnterpriseManager.Application.V1.Specific.City.Services.Validators;
using EnterpriseManager.Application.V1.Specific.City.UseCases;
using EnterpriseManager.Domain.General.Objects;
using EnterpriseManager.Domain.Specific.City.Entities;
using EnterpriseManager.Domain.Specific.City.Entities.Validators;
using EnterpriseManager.Infrastructure.General.Objects;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CityAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorWithDetails))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorWithDetails))]
		public IActionResult Get(long id)
		{
			IActionResult? iActionResult = null;

			ErrorWithDetails? errorDetails = null;

			try
			{
				CityAppSpecServVali.ValidateTheInputsOfTheGetMethod(id);

				CityAppSpecObje? cityAppSpecObje = _iCityAppSpecUseCase.Get(id);

				CityDomaSpecEnti? cityDomaSpecEnti = null;

				CityDomaSpecEntiVali.ValidateIfEntityExists(cityDomaSpecEnti);

				iActionResult = new JsonResult(cityAppSpecObje)
				{
					StatusCode = StatusCodes.Status201Created
				};
			}
			catch (InfrastructureLayerException infrastructureLayerException)
			{
				errorDetails = new ErrorWithDetails
				{
					Type = infrastructureLayerException.GetType().Name,
					Message = infrastructureLayerException.Message
				};

				iActionResult = StatusCode((int)infrastructureLayerException.HttpStatusCode, errorDetails);
			}
			catch (DomainLayerException domainLayerException)
			{
				errorDetails = new ErrorWithDetails
				{
					Type = domainLayerException.GetType().Name,
					Message = domainLayerException.Message
				};

				iActionResult = StatusCode((int)domainLayerException.HttpStatusCode, errorDetails);
			}
			catch (ApplicationLayerException applicationLayerException)
			{
				errorDetails = new ErrorWithDetails
				{
					Type = applicationLayerException.GetType().Name,
					Message = applicationLayerException.Message
				};

				iActionResult = StatusCode((int)applicationLayerException.HttpStatusCode, errorDetails);
			}
			catch (Exception exception)
			{
				errorDetails = new ErrorWithDetails
				{
					Type = exception.GetType().Name,
					Message = "An internal server error occurred: " + exception.Message
				};

				iActionResult = StatusCode((int)HttpStatusCode.InternalServerError, errorDetails);
			}

			return iActionResult;
		}
	}
}