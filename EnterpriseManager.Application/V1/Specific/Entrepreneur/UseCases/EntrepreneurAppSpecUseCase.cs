using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;
using EnterpriseManager.Application.V1.Specific.Entrepreneur.Services;
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

		public EntrepreneurAppSpecObje Get(long id)
		{
			EntrepreneurAppSpecObje EntrepreneurAppSpecObje = _iEntrepreneurAppSpecServ.Get(id);

			return EntrepreneurAppSpecObje;
		}
	}
}