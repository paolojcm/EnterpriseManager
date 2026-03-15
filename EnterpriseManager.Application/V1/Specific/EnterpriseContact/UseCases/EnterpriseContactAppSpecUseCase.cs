using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;
using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Services;
using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Services.Validators;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.EnterpriseContact.UseCases
{
	public class EnterpriseContactAppSpecUseCase : IEnterpriseContactAppSpecUseCase
	{
		private readonly ILogger<EnterpriseContactAppSpecUseCase> _iLogger;

		private IEnterpriseContactAppSpecServ _iEnterpriseContactAppSpecServ;

		public EnterpriseContactAppSpecUseCase(
			ILogger<EnterpriseContactAppSpecUseCase> iLogger,
			IEnterpriseContactAppSpecServ iEnterpriseContactAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iEnterpriseContactAppSpecServ = iEnterpriseContactAppSpecServ;
		}
		
		public async Task<EnterpriseContactAppSpecObje> GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId)
		{
			EnterpriseContactAppSpecServVali.ValidateTheInputsOfTheGetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsyncMethod(meanOfContactId, enterpriseId);

			EnterpriseContactAppSpecObje EnterpriseContactAppSpecObje = await _iEnterpriseContactAppSpecServ.GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(meanOfContactId, enterpriseId);

			return EnterpriseContactAppSpecObje;
		}

		public async Task<IEnumerable<EnterpriseContactAppSpecObje>> GetEnterpriseContactsByEnterpriseIdAsync(long enterpriseId)
		{
			IEnumerable<EnterpriseContactAppSpecObje> EnterpriseContactAppSpecObje = await _iEnterpriseContactAppSpecServ.GetEnterpriseContactsByEnterpriseIdAsync(enterpriseId);

			return EnterpriseContactAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateEnterpriseContactAsync(EnterpriseContactAppSpecObje? enterpriseContactAppSpecObje)
		{
			EnterpriseContactAppSpecServVali.ValidateTheInputsOfTheInsertOrUpdateEnterpriseContactAsyncMethod(enterpriseContactAppSpecObje);
			return await _iEnterpriseContactAppSpecServ.InsertOrUpdateEnterpriseContactAsync(enterpriseContactAppSpecObje);
		}

		public async Task<bool> DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId)
		{
			EnterpriseContactAppSpecServVali.ValidateTheInputsOfTheDeleteEnterpriseContactByIdAsyncMethod(meanOfContactId, enterpriseId);

			bool output = await _iEnterpriseContactAppSpecServ.DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(meanOfContactId, enterpriseId);

			return output;
		}
	}
}