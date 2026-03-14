using EnterpriseManager.Application.V1.Specific.MeanOfContact.Services;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects
{
	public class MeanOfContactAppSpecServ : IMeanOfContactAppSpecServ
	{
		private readonly ILogger<MeanOfContactAppSpecServ> _iLogger;

		public MeanOfContactAppSpecServ(ILogger<MeanOfContactAppSpecServ> iLogger)
		{
			_iLogger = iLogger;
		}

		public MeanOfContactAppSpecObje Get(long id)
		{
			MeanOfContactAppSpecObje MeanOfContactAppSpecObje = new MeanOfContactAppSpecObje();

			MeanOfContactAppSpecObje.Id = id;
			MeanOfContactAppSpecObje.Name = $"Name {id}";

			return MeanOfContactAppSpecObje;
		}
	}
}