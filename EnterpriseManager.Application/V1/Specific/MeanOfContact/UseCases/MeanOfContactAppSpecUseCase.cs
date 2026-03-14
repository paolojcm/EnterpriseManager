using EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.Services;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.UseCases;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases
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

		public MeanOfContactAppSpecObje Get(long id)
		{
			MeanOfContactAppSpecObje MeanOfContactAppSpecObje = _iMeanOfContactAppSpecServ.Get(id);

			return MeanOfContactAppSpecObje;
		}
	}
}