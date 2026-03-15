using EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.UseCases;
using EnterpriseManager.Domain.General.Objects;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EnterpriseManager.API.V1.Specific.MeanOfContact.Controllers
{
	///<Summary>
	/// This controller handles all MeanOfContact-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("MeanOfContact")]
	[SwaggerTag("This controller handles all MeanOfContact-related API requests.")]
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
		/// <param id="id"></param>
		/// <param name="Name asdadsas"></param>
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
		/// <response code="500">If an error or exception occurs.</response>
		[HttpGet("GetMeanOfContactById")]
		[EndpointSummary("It returns a MeanOfContact.")]
		[EndpointDescription("It returns a MeanOfContact by Id.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MeanOfContactAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> GetMeanOfContactByIdAsync(long id)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				MeanOfContactAppSpecObje? meanOfContactAppSpecObje = await _iMeanOfContactAppSpecUseCase.GetMeanOfContactByIdAsync(id);

				iActionResult = new JsonResult(meanOfContactAppSpecObje)
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
		/// Get a MeanOfContact by Id.
		/// </summary>
		/// <param meanOfContactAppSpecObje="name"></param>
		/// <returns>A MeanOfContact.</returns>
		/// <remarks>
		/// Sample reponse:
		///
		///     {
		///        "meanOfContactAppSpecObje": 1,
		///        "meanOfContactAppSpecObje": "XXX",
		///     }
		///
		/// </remarks>
		/// <response code="201">If the item is found.</response>
		/// <response code="404">If the item is not found.</response>
		/// <response code="500">If an error or exception occurs.</response>
		[HttpGet("GetMeansOfContactByName")]
		[EndpointSummary("It returns a MeanOfContact.")]
		[EndpointDescription("It returns a MeanOfContact by Name.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MeanOfContactAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> GetMeansOfContactByName(string? name)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				IEnumerable<MeanOfContactAppSpecObje>? meanOfContactAppSpecObje = await _iMeanOfContactAppSpecUseCase.GetMeansOfContactByNameAsync(name);

				iActionResult = new JsonResult(meanOfContactAppSpecObje)
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
		/// It inserts or updates a MeanOfContact by Id.
		/// </summary>
		/// <param meanOfContactAppSpecObje="meanOfContactAppSpecObje"></param>
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
		[HttpPost("InsertOrUpdateMeanOfContact")]
		[EndpointSummary("It inserts or updates a MeanOfContact.")]
		[EndpointDescription("It inserts or updates a MeanOfContact.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> InsertOrUpdateMeanOfContactAsync(MeanOfContactAppSpecObje? meanOfContactAppSpecObje)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				bool output = await _iMeanOfContactAppSpecUseCase.InsertOrUpdateMeanOfContactAsync(meanOfContactAppSpecObje);

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
		/// It deletes a MeanOfContact by Id.
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
		[HttpDelete("DeleteMeanOfContactById")]
		[EndpointSummary("It deletes a MeanOfContact.")]
		[EndpointDescription("It deletes a MeanOfContact.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> DeleteMeanOfContactByIdAsync(long id)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				bool output = await _iMeanOfContactAppSpecUseCase.DeleteMeanOfContactByIdAsync(id);

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