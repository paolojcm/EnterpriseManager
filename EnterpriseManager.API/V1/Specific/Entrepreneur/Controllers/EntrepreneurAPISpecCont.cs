using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;
using EnterpriseManager.Application.V1.Specific.Entrepreneur.UseCases;
using EnterpriseManager.Domain.General.Objects;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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
		/// Get a Entrepreneur by Id.
		/// </summary>
		/// <param id="id"></param>
		/// <param name="Name asdadsas"></param>
		/// <returns>A Entrepreneur.</returns>
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
		[HttpGet("GetEntrepreneurById")]
		[EndpointSummary("It returns a Entrepreneur.")]
		[EndpointDescription("It returns a Entrepreneur by Id.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EntrepreneurAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> GetEntrepreneurByIdAsync(long id)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				EntrepreneurAppSpecObje? entrepreneurAppSpecObje = await _iEntrepreneurAppSpecUseCase.GetEntrepreneurByIdAsync(id);

				iActionResult = new JsonResult(entrepreneurAppSpecObje)
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
		/// Get a Entrepreneur by Id.
		/// </summary>
		/// <param entrepreneurAppSpecObje="name"></param>
		/// <returns>A Entrepreneur.</returns>
		/// <remarks>
		/// Sample reponse:
		///
		///     {
		///        "entrepreneurAppSpecObje": 1,
		///        "entrepreneurAppSpecObje": "XXX",
		///     }
		///
		/// </remarks>
		/// <response code="201">If the item is found.</response>
		/// <response code="404">If the item is not found.</response>
		/// <response code="500">If an error or exception occurs.</response>
		[HttpGet("GetEntrepreneursByName")]
		[EndpointSummary("It returns a Entrepreneur.")]
		[EndpointDescription("It returns a Entrepreneur by Name.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EntrepreneurAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> GetEntrepreneursByName(string? name)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				IEnumerable<EntrepreneurAppSpecObje>? entrepreneurAppSpecObje = await _iEntrepreneurAppSpecUseCase.GetEntrepreneursByNameAsync(name);

				iActionResult = new JsonResult(entrepreneurAppSpecObje)
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
		/// It inserts or updates a Entrepreneur by Id.
		/// </summary>
		/// <param entrepreneurAppSpecObje="entrepreneurAppSpecObje"></param>
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
		[HttpPost("InsertOrUpdateEntrepreneur")]
		[EndpointSummary("It inserts or updates a Entrepreneur.")]
		[EndpointDescription("It inserts or updates a Entrepreneur.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> InsertOrUpdateEntrepreneurAsync(EntrepreneurAppSpecObje? entrepreneurAppSpecObje)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				bool output = await _iEntrepreneurAppSpecUseCase.InsertOrUpdateEntrepreneurAsync(entrepreneurAppSpecObje);

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
		/// It deletes a Entrepreneur by Id.
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
		[HttpDelete("DeleteEntrepreneurById")]
		[EndpointSummary("It deletes a Entrepreneur.")]
		[EndpointDescription("It deletes a Entrepreneur.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> DeleteEntrepreneurByIdAsync(long id)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				bool output = await _iEntrepreneurAppSpecUseCase.DeleteEntrepreneurByIdAsync(id);

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