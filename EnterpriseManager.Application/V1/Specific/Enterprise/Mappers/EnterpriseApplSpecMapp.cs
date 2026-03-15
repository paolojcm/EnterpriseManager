using EnterpriseManager.Application.V1.Specific.Enterprise.Objects;
using EnterpriseManager.Domain.Specific.Enterprise.Entities;

namespace EnterpriseManager.Application.Specific.Enterprise.Mappers
{
	public class EnterpriseApplSpecMapp
	{
		public static EnterpriseAppSpecObje MapToApplicationObject(EnterpriseDomaSpecEnti? enterpriseDomaSpecEnti)
		{
			EnterpriseAppSpecObje? enterpriseAppSpecObje = null;

			if (enterpriseDomaSpecEnti != null)
			{
				enterpriseAppSpecObje = new EnterpriseAppSpecObje();
				enterpriseAppSpecObje.Id = enterpriseDomaSpecEnti.Id;
				enterpriseAppSpecObje.Name = enterpriseDomaSpecEnti.Name;
				enterpriseAppSpecObje.Status = enterpriseDomaSpecEnti.Status;
				enterpriseAppSpecObje.EntrepreneurId = enterpriseDomaSpecEnti.EntrepreneurId;
				enterpriseAppSpecObje.OperatingSegmentId = enterpriseDomaSpecEnti.OperatingSegmentId;
				enterpriseAppSpecObje.CityId = enterpriseDomaSpecEnti.CityId;
			}

			return enterpriseAppSpecObje;
		}

		public static EnterpriseDomaSpecEnti MapToDomainEntity(EnterpriseAppSpecObje? enterpriseAppSpecObje)
		{
			EnterpriseDomaSpecEnti? enterpriseDomaSpecEnti = null;

			if (enterpriseAppSpecObje != null)
			{
				enterpriseDomaSpecEnti = new EnterpriseDomaSpecEnti();
				enterpriseDomaSpecEnti.Id = enterpriseAppSpecObje.Id;
				enterpriseDomaSpecEnti.Name = enterpriseAppSpecObje.Name;
				enterpriseDomaSpecEnti.Status = enterpriseAppSpecObje.Status;
				enterpriseDomaSpecEnti.EntrepreneurId = enterpriseAppSpecObje.EntrepreneurId;
				enterpriseDomaSpecEnti.OperatingSegmentId = enterpriseAppSpecObje.OperatingSegmentId;
				enterpriseDomaSpecEnti.CityId = enterpriseAppSpecObje.CityId;
			}

			return enterpriseDomaSpecEnti;
		}
	}
}