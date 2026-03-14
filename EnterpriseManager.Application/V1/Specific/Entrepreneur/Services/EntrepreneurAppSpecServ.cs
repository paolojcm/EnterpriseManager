using EnterpriseManager.Application.V1.Specific.Entrepreneur.Services;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects
{
	public class EntrepreneurAppSpecServ : IEntrepreneurAppSpecServ
	{
		private readonly ILogger<EntrepreneurAppSpecServ> _iLogger;

		public EntrepreneurAppSpecServ(ILogger<EntrepreneurAppSpecServ> iLogger)
		{
			_iLogger = iLogger;
		}

		public EntrepreneurAppSpecObje Get(long id)
		{
			EntrepreneurAppSpecObje EntrepreneurAppSpecObje = new EntrepreneurAppSpecObje();

			EntrepreneurAppSpecObje.Id = id;
			EntrepreneurAppSpecObje.Name = $"Name {id}";

			return EntrepreneurAppSpecObje;
		}
	}
}