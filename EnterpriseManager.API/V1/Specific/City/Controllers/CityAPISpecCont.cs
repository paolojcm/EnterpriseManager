using EnterpriseManager.Application.V1.Specific.City.Objects;
using EnterpriseManager.Application.V1.Specific.City.UseCases;
using EnterpriseManager.Domain.General.Objects;
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
		/// <param id="id"></param>
		/// <param name="Name asdadsas"></param>
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
		/// <response code="500">If an error or exception occurs.</response>
		[HttpGet("GetCityById")]
		[EndpointSummary("It returns a City.")]
		[EndpointDescription("It returns a City by Id.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CityAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> GetCityByIdAsync(long id)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				CityAppSpecObje? cityAppSpecObje = await _iCityAppSpecUseCase.GetCityByIdAsync(id);

				iActionResult = new JsonResult(cityAppSpecObje)
				{
					StatusCode = StatusCodes.Status201Created
				};
			}
			catch (InfrastructureLayerException infrastructureLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = infrastructureLayerException.GetType().Name,
					Message = infrastructureLayerException.Message
				};

				iActionResult = StatusCode((int)infrastructureLayerException.HttpStatusCode, actionResultObject);
			}
			catch (DomainLayerException domainLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = domainLayerException.GetType().Name,
					Message = domainLayerException.Message
				};

				iActionResult = StatusCode((int)domainLayerException.HttpStatusCode, actionResultObject);
			}
			catch (ApplicationLayerException applicationLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = applicationLayerException.GetType().Name,
					Message = applicationLayerException.Message
				};

				iActionResult = StatusCode((int)applicationLayerException.HttpStatusCode, actionResultObject);
			}
			catch (Exception exception)
			{
				actionResultObject = new ActionResultObject
				{
					Type = exception.GetType().Name,
					Message = $"An internal server error occurred: {exception.Message}"
				};

				iActionResult = StatusCode((int)HttpStatusCode.InternalServerError, actionResultObject);
			}

			return iActionResult;
		}

		/// <summary>
		/// Get a City by Id.
		/// </summary>
		/// <param cityAppSpecObje="name"></param>
		/// <returns>A City.</returns>
		/// <remarks>
		/// Sample reponse:
		///
		///     {
		///        "cityAppSpecObje": 1,
		///        "cityAppSpecObje": "XXX",
		///     }
		///
		/// </remarks>
		/// <response code="201">If the item is found.</response>
		/// <response code="404">If the item is not found.</response>
		/// <response code="500">If an error or exception occurs.</response>
		[HttpGet("GetCitiesByName")]
		[EndpointSummary("It returns a City.")]
		[EndpointDescription("It returns a City by Name.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CityAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> GetCitiesByNameAsync(string? name)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				IEnumerable<CityAppSpecObje>? cityAppSpecObje = await _iCityAppSpecUseCase.GetCitiesByNameAsync(name);

				iActionResult = new JsonResult(cityAppSpecObje)
				{
					StatusCode = StatusCodes.Status201Created
				};
			}
			catch (InfrastructureLayerException infrastructureLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = infrastructureLayerException.GetType().Name,
					Message = infrastructureLayerException.Message
				};

				iActionResult = StatusCode((int)infrastructureLayerException.HttpStatusCode, actionResultObject);
			}
			catch (DomainLayerException domainLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = domainLayerException.GetType().Name,
					Message = domainLayerException.Message
				};

				iActionResult = StatusCode((int)domainLayerException.HttpStatusCode, actionResultObject);
			}
			catch (ApplicationLayerException applicationLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = applicationLayerException.GetType().Name,
					Message = applicationLayerException.Message
				};

				iActionResult = StatusCode((int)applicationLayerException.HttpStatusCode, actionResultObject);
			}
			catch (Exception exception)
			{
				actionResultObject = new ActionResultObject
				{
					Type = exception.GetType().Name,
					Message = $"An internal server error occurred: {exception.Message}"
				};

				iActionResult = StatusCode((int)HttpStatusCode.InternalServerError, actionResultObject);
			}

			return iActionResult;
		}

		/// <summary>
		/// It inserts or updates a City by Id.
		/// </summary>
		/// <param cityAppSpecObje="cityAppSpecObje"></param>
		/// <returns>True or False</returns>
		/// <remarks>
		/// Sample reponse:
		///
		///		{
		///		  "output": true
		///		}
		///
		/// </remarks>
		/// <response code="201">Whether it worked or not.</response>
		/// <response code="500">If an error or exception occurs.</response>
		[HttpPost("InsertOrUpdateCity")]
		[EndpointSummary("It inserts or updates a City.")]
		[EndpointDescription("It inserts or updates a City.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> InsertOrUpdateCityAsync(CityAppSpecObje? cityAppSpecObje)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				bool output = await _iCityAppSpecUseCase.InsertOrUpdateCityAsync(cityAppSpecObje);

				actionResultObject = new ActionResultObject
				{
					Status = true,
					Message = output
				};

				iActionResult = new JsonResult(actionResultObject)
				{
					StatusCode = StatusCodes.Status201Created
				};
			}
			catch (InfrastructureLayerException infrastructureLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = infrastructureLayerException.GetType().Name,
					Message = infrastructureLayerException.Message
				};

				iActionResult = StatusCode((int)infrastructureLayerException.HttpStatusCode, actionResultObject);
			}
			catch (DomainLayerException domainLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = domainLayerException.GetType().Name,
					Message = domainLayerException.Message
				};

				iActionResult = StatusCode((int)domainLayerException.HttpStatusCode, actionResultObject);
			}
			catch (ApplicationLayerException applicationLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = applicationLayerException.GetType().Name,
					Message = applicationLayerException.Message
				};

				iActionResult = StatusCode((int)applicationLayerException.HttpStatusCode, actionResultObject);
			}
			catch (Exception exception)
			{
				actionResultObject = new ActionResultObject
				{
					Type = exception.GetType().Name,
					Message = $"An internal server error occurred: {exception.Message}"
				};

				iActionResult = StatusCode((int)HttpStatusCode.InternalServerError, actionResultObject);
			}

			return iActionResult;
		}

		/// <summary>
		/// It deletes a City by Id.
		/// </summary>
		/// <param id="id"></param>
		/// <returns>True or False</returns>
		/// <remarks>
		/// Sample reponse:
		///
		///		{
		///		  "output": true
		///		}
		///
		/// </remarks>
		/// <response code="201">Whether it worked or not.</response>
		/// <response code="500">If an error or exception occurs.</response>
		[HttpDelete("DeleteCityById")]
		[EndpointSummary("It deletes a City.")]
		[EndpointDescription("It deletes a City.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> DeleteCityByIdAsync(long id)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				bool output = await _iCityAppSpecUseCase.DeleteCityByIdAsync(id);

				actionResultObject = new ActionResultObject
				{
					Status = true,
					Message = output
				};

				iActionResult = new JsonResult(actionResultObject)
				{
					StatusCode = StatusCodes.Status201Created
				};
			}
			catch (InfrastructureLayerException infrastructureLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = infrastructureLayerException.GetType().Name,
					Message = infrastructureLayerException.Message
				};

				iActionResult = StatusCode((int)infrastructureLayerException.HttpStatusCode, actionResultObject);
			}
			catch (DomainLayerException domainLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = domainLayerException.GetType().Name,
					Message = domainLayerException.Message
				};

				iActionResult = StatusCode((int)domainLayerException.HttpStatusCode, actionResultObject);
			}
			catch (ApplicationLayerException applicationLayerException)
			{
				actionResultObject = new ActionResultObject
				{
					Type = applicationLayerException.GetType().Name,
					Message = applicationLayerException.Message
				};

				iActionResult = StatusCode((int)applicationLayerException.HttpStatusCode, actionResultObject);
			}
			catch (Exception exception)
			{
				actionResultObject = new ActionResultObject
				{
					Type = exception.GetType().Name,
					Message = $"An internal server error occurred: {exception.Message}"
				};

				iActionResult = StatusCode((int)HttpStatusCode.InternalServerError, actionResultObject);
			}

			return iActionResult;
		}
	}
}