using EnterpriseManager.Application.V1.Specific.State.Services;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.State.Objects
{
	public class StateAppSpecServ : IStateAppSpecServ
	{
		private readonly ILogger<StateAppSpecServ> _iLogger;

		public StateAppSpecServ(ILogger<StateAppSpecServ> iLogger)
		{
			_iLogger = iLogger;
		}

		public StateAppSpecObje Get(long id)
		{
			StateAppSpecObje StateAppSpecObje = new StateAppSpecObje();

			StateAppSpecObje.Id = id;
			StateAppSpecObje.Acronym = $"Acronym {id}";
			StateAppSpecObje.Name = $"Name {id}";
			StateAppSpecObje.CountryId = 1;

			return StateAppSpecObje;
		}
	}
}