using EnterpriseManager.Application.V1.Specific.Entrepreneur.Services;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.Services;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.Services.Validators;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.MeanOfContact.UseCases
{
	public class MeanOfContactAppSpecUseCase : IMeanOfContactAppSpecUseCase
	{
		private readonly ILogger<MeanOfContactAppSpecUseCase> _iLogger;

		private IMeanOfContactAppSpecServ _iMeanOfContactAppSpecServ;

		public MeanOfContactAppSpecUseCase(
			ILogger<MeanOfContactAppSpecUseCase> iLogger,
			IMeanOfContactAppSpecServ iMeanOfContactAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iMeanOfContactAppSpecServ = iMeanOfContactAppSpecServ;
		}

		public async Task<MeanOfContactAppSpecObje> GetMeanOfContactByIdAsync(long id)
		{
			MeanOfContactAppSpecServVali.ValidateTheInputsOfTheGetMeanOfContactByIdAsyncMethod(id);

			MeanOfContactAppSpecObje meanOfContactAppSpecObje = await _iMeanOfContactAppSpecServ.GetMeanOfContactByIdAsync(id);

			return meanOfContactAppSpecObje;
		}

		public async Task<IEnumerable<MeanOfContactAppSpecObje>> GetMeansOfContactByNameAsync(string? name)
		{
			IEnumerable<MeanOfContactAppSpecObje> meanOfContactAppSpecObje = await _iMeanOfContactAppSpecServ.GetMeansOfContactByNameAsync(name);

			return meanOfContactAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateMeanOfContactAsync(MeanOfContactAppSpecObje? meanOfContactAppSpecObje)
		{
			MeanOfContactAppSpecServVali.ValidateTheInputsOfTheInsertOrUpdateMeanOfContactAsyncMethod(meanOfContactAppSpecObje);
			return await _iMeanOfContactAppSpecServ.InsertOrUpdateMeanOfContactAsync(meanOfContactAppSpecObje);
		}

		public async Task<bool> DeleteMeanOfContactByIdAsync(long id)
		{
			MeanOfContactAppSpecServVali.ValidateTheInputsOfTheDeleteMeanOfContactByIdAsyncMethod(id);

			bool output = await _iMeanOfContactAppSpecServ.DeleteMeanOfContactByIdAsync(id);

			return output;
		}
	}
}