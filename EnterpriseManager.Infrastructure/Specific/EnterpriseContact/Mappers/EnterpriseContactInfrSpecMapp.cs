using EnterpriseManager.Domain.Specific.EnterpriseContact.Entities;
using EnterpriseManager.Infrastructure.Specific.EnterpriseContact.Models;

namespace EnterpriseManager.Infrastructure.Specific.EnterpriseContact.Mappers
{
	public class EnterpriseContactInfrSpecMapp
	{
		public static EnterpriseContactInfrSpecMode MapToPersistenceModel(EnterpriseContactDomaSpecEnti enterpriseContactDomaSpecEnti)
		{
			EnterpriseContactInfrSpecMode? enterpriseContactInfrSpecMode = null;

			if (enterpriseContactDomaSpecEnti != null)
			{
				enterpriseContactInfrSpecMode = new EnterpriseContactInfrSpecMode();
				enterpriseContactInfrSpecMode.MeanOfContactId = enterpriseContactDomaSpecEnti.MeanOfContactId;
				enterpriseContactInfrSpecMode.EnterpriseId = enterpriseContactDomaSpecEnti.EnterpriseId;
				enterpriseContactInfrSpecMode.Contents = enterpriseContactDomaSpecEnti.Contents;
			}

			return enterpriseContactInfrSpecMode;
		}

		public static EnterpriseContactDomaSpecEnti MapToDomainEntity(EnterpriseContactInfrSpecMode enterpriseContactInfrSpecMode)
		{
			EnterpriseContactDomaSpecEnti? enterpriseContactDomaSpecEnti = null;

			if (enterpriseContactInfrSpecMode != null)
			{
				enterpriseContactDomaSpecEnti = new EnterpriseContactDomaSpecEnti();
				enterpriseContactDomaSpecEnti.MeanOfContactId = enterpriseContactInfrSpecMode.MeanOfContactId;
				enterpriseContactDomaSpecEnti.EnterpriseId = enterpriseContactInfrSpecMode.EnterpriseId;
				enterpriseContactDomaSpecEnti.Contents = enterpriseContactInfrSpecMode.Contents;
			}

			return enterpriseContactDomaSpecEnti;
		}
	}
}