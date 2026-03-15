using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;
using EnterpriseManager.Application.V1.Specific.Entrepreneur.Services;
using EnterpriseManager.Application.V1.Specific.Entrepreneur.Services.Validators;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.Entrepreneur.UseCases
{
	public class EntrepreneurAppSpecUseCase : IEntrepreneurAppSpecUseCase
	{
		private readonly ILogger<EntrepreneurAppSpecUseCase> _iLogger;

		private IEntrepreneurAppSpecServ _iEntrepreneurAppSpecServ;

		public EntrepreneurAppSpecUseCase(
			ILogger<EntrepreneurAppSpecUseCase> iLogger,
			IEntrepreneurAppSpecServ iEntrepreneurAppSpecServ
			)
		{
			_iLogger = iLogger;
			_iEntrepreneurAppSpecServ = iEntrepreneurAppSpecServ;
		}

		public async Task<EntrepreneurAppSpecObje> GetEntrepreneurByIdAsync(long id)
		{
			EntrepreneurAppSpecServVali.ValidateTheInputsOfTheGetEntrepreneurByIdAsyncMethod(id);

			EntrepreneurAppSpecObje EntrepreneurAppSpecObje = await _iEntrepreneurAppSpecServ.GetEntrepreneurByIdAsync(id);

			return EntrepreneurAppSpecObje;
		}

		public async Task<IEnumerable<EntrepreneurAppSpecObje>> GetEntrepreneursByNameAsync(string? name)
		{
			IEnumerable<EntrepreneurAppSpecObje> EntrepreneurAppSpecObje = await _iEntrepreneurAppSpecServ.GetEntrepreneursByNameAsync(name);

			return EntrepreneurAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateEntrepreneurAsync(EntrepreneurAppSpecObje? entrepreneurAppSpecObje)
		{
			EntrepreneurAppSpecServVali.ValidateTheInputsOfTheInsertOrUpdateEntrepreneurAsyncMethod(entrepreneurAppSpecObje);
			return await _iEntrepreneurAppSpecServ.InsertOrUpdateEntrepreneurAsync(entrepreneurAppSpecObje);
		}

		public async Task<bool> DeleteEntrepreneurByIdAsync(long id)
		{
			EntrepreneurAppSpecServVali.ValidateTheInputsOfTheDeleteEntrepreneurByIdAsyncMethod(id);

			bool output = await _iEntrepreneurAppSpecServ.DeleteEntrepreneurByIdAsync(id);

			return output;
		}
	}
}