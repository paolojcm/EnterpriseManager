using EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects;
using EnterpriseManager.Application.V1.Specific.OperatingSegment.Services;
using EnterpriseManager.Application.V1.Specific.OperatingSegment.Services.Validators;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases
{
	public class OperatingSegmentAppSpecUseCase : IOperatingSegmentAppSpecUseCase
	{
		private readonly ILogger<OperatingSegmentAppSpecUseCase> _iLogger;

		private IOperatingSegmentAppSpecServ _iOperatingSegmentAppSpecServ;

		public OperatingSegmentAppSpecUseCase(
			ILogger<OperatingSegmentAppSpecUseCase> iLogger,
			IOperatingSegmentAppSpecServ iOperatingSegmentAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iOperatingSegmentAppSpecServ = iOperatingSegmentAppSpecServ;
		}

		public async Task<OperatingSegmentAppSpecObje> GetOperatingSegmentByIdAsync(long id)
		{
			OperatingSegmentAppSpecServVali.ValidateTheInputsOfTheGetOperatingSegmentByIdAsyncMethod(id);

			OperatingSegmentAppSpecObje OperatingSegmentAppSpecObje = await _iOperatingSegmentAppSpecServ.GetOperatingSegmentByIdAsync(id);

			return OperatingSegmentAppSpecObje;
		}

		public async Task<IEnumerable<OperatingSegmentAppSpecObje>> GetOperatingSegmentsByNameAsync(string? name)
		{
			IEnumerable<OperatingSegmentAppSpecObje> OperatingSegmentAppSpecObje = await _iOperatingSegmentAppSpecServ.GetOperatingSegmentsByNameAsync(name);

			return OperatingSegmentAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateOperatingSegmentAsync(OperatingSegmentAppSpecObje? operatingSegmentAppSpecObje)
		{
			OperatingSegmentAppSpecServVali.ValidateTheInputsOfTheInsertOrUpdateOperatingSegmentAsyncMethod(operatingSegmentAppSpecObje);
			return await _iOperatingSegmentAppSpecServ.InsertOrUpdateOperatingSegmentAsync(operatingSegmentAppSpecObje);
		}

		public async Task<bool> DeleteOperatingSegmentByIdAsync(long id)
		{
			OperatingSegmentAppSpecServVali.ValidateTheInputsOfTheDeleteOperatingSegmentByIdAsyncMethod(id);

			bool output = await _iOperatingSegmentAppSpecServ.DeleteOperatingSegmentByIdAsync(id);

			return output;
		}
	}
}