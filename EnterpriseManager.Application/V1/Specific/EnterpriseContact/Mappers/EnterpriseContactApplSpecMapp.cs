using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;
using EnterpriseManager.Domain.Specific.EnterpriseContact.Entities;

namespace EnterpriseManager.Application.Specific.EnterpriseContact.Mappers
{
	public class EnterpriseContactApplSpecMapp
	{
		public static EnterpriseContactAppSpecObje MapToApplicationObject(EnterpriseContactDomaSpecEnti? enterpriseContactDomaSpecEnti)
		{
			EnterpriseContactAppSpecObje? enterpriseContactAppSpecObje = null;

			if (enterpriseContactDomaSpecEnti != null)
			{
				enterpriseContactAppSpecObje = new EnterpriseContactAppSpecObje();
				enterpriseContactAppSpecObje.MeanOfContactId = enterpriseContactDomaSpecEnti.MeanOfContactId;
				enterpriseContactAppSpecObje.EnterpriseId = enterpriseContactDomaSpecEnti.EnterpriseId;
				enterpriseContactAppSpecObje.Contents = enterpriseContactDomaSpecEnti.Contents;
			}

			return enterpriseContactAppSpecObje;
		}

		public static EnterpriseContactDomaSpecEnti MapToDomainEntity(EnterpriseContactAppSpecObje? enterpriseContactAppSpecObje)
		{
			EnterpriseContactDomaSpecEnti? enterpriseContactDomaSpecEnti = null;

			if (enterpriseContactAppSpecObje != null)
			{
				enterpriseContactDomaSpecEnti = new EnterpriseContactDomaSpecEnti();
				enterpriseContactDomaSpecEnti.MeanOfContactId = enterpriseContactAppSpecObje.MeanOfContactId;
				enterpriseContactDomaSpecEnti.EnterpriseId = enterpriseContactAppSpecObje.EnterpriseId;
				enterpriseContactDomaSpecEnti.Contents = enterpriseContactAppSpecObje.Contents;
			}

			return enterpriseContactDomaSpecEnti;
		}
	}
}