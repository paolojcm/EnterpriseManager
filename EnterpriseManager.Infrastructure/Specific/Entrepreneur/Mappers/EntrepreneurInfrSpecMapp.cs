using EnterpriseManager.Domain.Specific.Entrepreneur.Entities;
using EnterpriseManager.Infrastructure.Specific.Entrepreneur.Models;
using EnterpriseManager.Infrastructure.Specific.MeanOfContact.Models;

namespace EnterpriseManager.Infrastructure.Specific.Entrepreneur.Mappers
{
	public class EntrepreneurInfrSpecMapp
	{
		public static EntrepreneurInfrSpecMode MapToPersistenceModel(EntrepreneurDomaSpecEnti entrepreneurDomaSpecEnti)
		{
			EntrepreneurInfrSpecMode? entrepreneurInfrSpecMode = null;

			if (entrepreneurDomaSpecEnti != null)
			{
				entrepreneurInfrSpecMode = new EntrepreneurInfrSpecMode();
				entrepreneurInfrSpecMode.Id = entrepreneurDomaSpecEnti.Id;
				entrepreneurInfrSpecMode.Name = entrepreneurDomaSpecEnti.Name;
			}

			return entrepreneurInfrSpecMode;
		}

		public static EntrepreneurDomaSpecEnti MapToDomainEntity(EntrepreneurInfrSpecMode entrepreneurInfrSpecMode)
		{
			EntrepreneurDomaSpecEnti? entrepreneurDomaSpecEnti = null;

			if (entrepreneurInfrSpecMode != null)
			{
				entrepreneurDomaSpecEnti = new EntrepreneurDomaSpecEnti();
				entrepreneurDomaSpecEnti.Id = entrepreneurInfrSpecMode.Id;
				entrepreneurDomaSpecEnti.Name = entrepreneurInfrSpecMode.Name;
			}

			return entrepreneurDomaSpecEnti;
		}
	}
}