using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;
using EnterpriseManager.Application.V1.Specific.State.Objects;
using EnterpriseManager.Domain.Specific.Entrepreneur.Entities;

namespace EnterpriseManager.Application.Specific.Entrepreneur.Mappers
{
	public class EntrepreneurApplSpecMapp
	{
		public static EntrepreneurAppSpecObje MapToApplicationObject(EntrepreneurDomaSpecEnti? entrepreneurDomaSpecEnti)
		{
			EntrepreneurAppSpecObje? entrepreneurAppSpecObje = null;

			if (entrepreneurDomaSpecEnti != null)
			{
				entrepreneurAppSpecObje = new EntrepreneurAppSpecObje();
				entrepreneurAppSpecObje.Id = entrepreneurDomaSpecEnti.Id;
				entrepreneurAppSpecObje.Name = entrepreneurDomaSpecEnti.Name;
			}

			return entrepreneurAppSpecObje;
		}

		public static EntrepreneurDomaSpecEnti MapToDomainEntity(EntrepreneurAppSpecObje? entrepreneurAppSpecObje)
		{
			EntrepreneurDomaSpecEnti? entrepreneurDomaSpecEnti = null;

			if (entrepreneurAppSpecObje != null)
			{
				entrepreneurDomaSpecEnti = new EntrepreneurDomaSpecEnti();
				entrepreneurDomaSpecEnti.Id = entrepreneurAppSpecObje.Id;
				entrepreneurDomaSpecEnti.Name = entrepreneurAppSpecObje.Name;
			}

			return entrepreneurDomaSpecEnti;
		}
	}
}