using EnterpriseManager.Domain.Specific.MeanOfContact.Entities;
using EnterpriseManager.Infrastructure.Specific.MeanOfContact.Models;

namespace EnterpriseManager.Infrastructure.Specific.MeanOfContact.Mappers
{
	public class MeanOfContactInfrSpecMapp
	{
		public static MeanOfContactInfrSpecMode MapToPersistenceModel(MeanOfContactDomaSpecEnti meanOfContactDomaSpecEnti)
		{
			MeanOfContactInfrSpecMode? meanOfContactInfrSpecMode = null;

			if (meanOfContactDomaSpecEnti != null)
			{
				meanOfContactInfrSpecMode = new MeanOfContactInfrSpecMode();
				meanOfContactInfrSpecMode.Id = meanOfContactDomaSpecEnti.Id;
				meanOfContactInfrSpecMode.Name = meanOfContactDomaSpecEnti.Name;
			}

			return meanOfContactInfrSpecMode;
		}

		public static MeanOfContactDomaSpecEnti MapToDomainEntity(MeanOfContactInfrSpecMode meanOfContactInfrSpecMode)
		{
			MeanOfContactDomaSpecEnti? meanOfContactDomaSpecEnti = null;

			if (meanOfContactInfrSpecMode != null)
			{
				meanOfContactDomaSpecEnti = new MeanOfContactDomaSpecEnti();
				meanOfContactDomaSpecEnti.Id = meanOfContactInfrSpecMode.Id;
				meanOfContactDomaSpecEnti.Name = meanOfContactInfrSpecMode.Name;
			}

			return meanOfContactDomaSpecEnti;
		}
	}
}