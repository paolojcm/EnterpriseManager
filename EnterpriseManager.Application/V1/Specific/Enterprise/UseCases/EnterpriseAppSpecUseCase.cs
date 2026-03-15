using EnterpriseManager.Application.V1.Specific.Enterprise.Objects;
using EnterpriseManager.Application.V1.Specific.Enterprise.Services;
using EnterpriseManager.Application.V1.Specific.Enterprise.Services.Validators;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.Enterprise.UseCases
{
	public class EnterpriseAppSpecUseCase : IEnterpriseAppSpecUseCase
	{
		private readonly ILogger<EnterpriseAppSpecUseCase> _iLogger;

		private IEnterpriseAppSpecServ _iEnterpriseAppSpecServ;

		public EnterpriseAppSpecUseCase(
			ILogger<EnterpriseAppSpecUseCase> iLogger,
			IEnterpriseAppSpecServ iEnterpriseAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iEnterpriseAppSpecServ = iEnterpriseAppSpecServ;
		}

		public async Task<EnterpriseAppSpecObje> GetEnterpriseByIdAsync(long id)
		{
			EnterpriseAppSpecServVali.ValidateTheInputsOfTheGetEnterpriseByIdAsyncMethod(id);

			EnterpriseAppSpecObje enterpriseAppSpecObje = await _iEnterpriseAppSpecServ.GetEnterpriseByIdAsync(id);

			return enterpriseAppSpecObje;
		}

		public async Task<IEnumerable<EnterpriseAppSpecObje>> GetEnterprisesByNameAsync(string? name)
		{
			IEnumerable<EnterpriseAppSpecObje> enterpriseAppSpecObje = await _iEnterpriseAppSpecServ.GetEnterprisesByNameAsync(name);

			return enterpriseAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateEnterpriseAsync(EnterpriseAppSpecObje? enterpriseAppSpecObje)
		{
			EnterpriseAppSpecServVali.ValidateTheInputsOfTheInsertOrUpdateEnterpriseAsyncMethod(enterpriseAppSpecObje);
			return await _iEnterpriseAppSpecServ.InsertOrUpdateEnterpriseAsync(enterpriseAppSpecObje);
		}

		public async Task<bool> DeleteEnterpriseByIdAsync(long id)
		{
			EnterpriseAppSpecServVali.ValidateTheInputsOfTheDeleteEnterpriseByIdAsyncMethod(id);

			bool output = await _iEnterpriseAppSpecServ.DeleteEnterpriseByIdAsync(id);

			return output;
		}
	}
}