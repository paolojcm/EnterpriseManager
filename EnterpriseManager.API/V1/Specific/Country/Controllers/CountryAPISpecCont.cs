using EnterpriseManager.Application.V1.Specific.Country.Objects;
using EnterpriseManager.Application.V1.Specific.Country.UseCases;
using EnterpriseManager.Domain.General.Objects;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EnterpriseManager.API.V1.Specific.Country.Controllers
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
		/// Get a Country by MeanOfContactId.
		/// </summary>
		/// <param id="id"></param>
		/// <param name="Name asdadsas"></param>
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
		/// <response code="500">If an error or exception occurs.</response>
		[HttpGet("GetCountryById")]
		[EndpointSummary("It returns a Country.")]
		[EndpointDescription("It returns a Country by Id.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CountryAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> GetCountryByIdAsync(long id)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				CountryAppSpecObje? countryAppSpecObje = await _iCountryAppSpecUseCase.GetCountryByIdAsync(id);

				iActionResult = new JsonResult(countryAppSpecObje)
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
		/// Get a Country by MeanOfContactId.
		/// </summary>
		/// <param countryAppSpecObje="name"></param>
		/// <returns>A Country.</returns>
		/// <remarks>
		/// Sample reponse:
		///
		///     {
		///        "countryAppSpecObje": 1,
		///        "countryAppSpecObje": "XXX",
		///     }
		///
		/// </remarks>
		/// <response code="201">If the item is found.</response>
		/// <response code="404">If the item is not found.</response>
		/// <response code="500">If an error or exception occurs.</response>
		[HttpGet("GetCountriesByName")]
		[EndpointSummary("It returns a Country.")]
		[EndpointDescription("It returns a Country by Name.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CountryAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> GetCountriesByNameAsync(string? name)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				IEnumerable<CountryAppSpecObje>? countryAppSpecObje = await _iCountryAppSpecUseCase.GetCountriesByNameAsync(name);

				iActionResult = new JsonResult(countryAppSpecObje)
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
		/// It inserts or updates a Country by MeanOfContactId.
		/// </summary>
		/// <param countryAppSpecObje="countryAppSpecObje"></param>
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
		[HttpPost("InsertOrUpdateCountry")]
		[EndpointSummary("It inserts or updates a Country.")]
		[EndpointDescription("It inserts or updates a Country.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> InsertOrUpdateCountryAsync(CountryAppSpecObje? countryAppSpecObje)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				bool output = await _iCountryAppSpecUseCase.InsertOrUpdateCountryAsync(countryAppSpecObje);

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
		/// It deletes a Country by MeanOfContactId.
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
		[HttpDelete("DeleteCountryById")]
		[EndpointSummary("It deletes a Country.")]
		[EndpointDescription("It deletes a Country.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> DeleteCountryByIdAsync(long id)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				bool output = await _iCountryAppSpecUseCase.DeleteCountryByIdAsync(id);

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