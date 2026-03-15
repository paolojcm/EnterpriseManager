using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;
using EnterpriseManager.Application.V1.Specific.EnterpriseContact.UseCases;
using EnterpriseManager.Domain.General.Objects;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EnterpriseManager.API.V1.Specific.EnterpriseContact.Controllers
{
	///<Summary>
	/// This controller handles all EnterpriseContact-related API requests.
	///</Summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	[Tags("Enterprise Contact")]
	[SwaggerTag("This controller handles all EnterpriseContact-related API requests.")]
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
		/// Get an EnterpriseContact by MeanOfContactId and EnterpriseId.
		/// </summary>
		/// <param meanOfContactId="meanOfContactId"></param>
		/// <param enterpriseId="enterpriseId"></param>
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
		/// <response code="500">If an error or exception occurs.</response>
		[HttpGet("GetEnterpriseContactByMeanOfContactIdAndEnterpriseId")]
		[EndpointSummary("It returns an Enterprise Contact.")]
		[EndpointDescription("It returns an Enterprise Contact by Id.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EnterpriseContactAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				EnterpriseContactAppSpecObje? enterpriseContactAppSpecObje = await _iEnterpriseContactAppSpecUseCase.GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(meanOfContactId, enterpriseId);

				iActionResult = new JsonResult(enterpriseContactAppSpecObje)
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
		/// Get an EnterpriseContact by MeanOfContactId.
		/// </summary>
		/// <param enterpriseContactAppSpecObje="name"></param>
		/// <returns>A EnterpriseContact.</returns>
		/// <remarks>
		/// Sample reponse:
		///
		///     {
		///        "enterpriseContactAppSpecObje": 1,
		///        "enterpriseContactAppSpecObje": "XXX",
		///     }
		///
		/// </remarks>
		/// <response code="201">If the item is found.</response>
		/// <response code="404">If the item is not found.</response>
		/// <response code="500">If an error or exception occurs.</response>
		[HttpGet("GetEnterpriseContactsByEnterpriseId")]
		[EndpointSummary("It returns an EnterpriseContact.")]
		[EndpointDescription("It returns an EnterpriseContact by Name.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EnterpriseContactAppSpecObje))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> GetEnterpriseContactsByEnterpriseIdAsync(long enterpriseId)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				IEnumerable<EnterpriseContactAppSpecObje>? enterpriseContactAppSpecObje = await _iEnterpriseContactAppSpecUseCase.GetEnterpriseContactsByEnterpriseIdAsync(enterpriseId);

				iActionResult = new JsonResult(enterpriseContactAppSpecObje)
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
		/// It inserts or updates an EnterpriseContact by MeanOfContactId.
		/// </summary>
		/// <param enterpriseContactAppSpecObje="enterpriseContactAppSpecObje"></param>
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
		[HttpPost("InsertOrUpdateEnterpriseContact")]
		[EndpointSummary("It inserts or updates an EnterpriseContact.")]
		[EndpointDescription("It inserts or updates an EnterpriseContact.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> InsertOrUpdateEnterpriseContactAsync(EnterpriseContactAppSpecObje? enterpriseContactAppSpecObje)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				bool output = await _iEnterpriseContactAppSpecUseCase.InsertOrUpdateEnterpriseContactAsync(enterpriseContactAppSpecObje);

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
		/// It deletes an Enterprise Contact by MeanOfContactId.
		/// </summary>
		/// <param meanOfContactId="meanOfContactId"></param>
		/// <param enterpriseId="enterpriseId"></param>
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
		[HttpDelete("DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseId")]
		[EndpointSummary("It deletes an Enterprise Contact.")]
		[EndpointDescription("It deletes an Enterprise Contact.")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResultObject))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResultObject))]
		public async Task<IActionResult> DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId)
		{
			IActionResult? iActionResult = null;

			ActionResultObject? actionResultObject = null;

			try
			{
				bool output = await _iEnterpriseContactAppSpecUseCase.DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(meanOfContactId, enterpriseId);

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