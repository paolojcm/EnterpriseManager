using EnterpriseManager.Domain.Specific.Enterprise.Entities;
using EnterpriseManager.Infrastructure.Specific.Enterprise.Models;

namespace EnterpriseManager.Infrastructure.Specific.Enterprise.Mappers
{
	public class EnterpriseInfrSpecMapp
	{
		public static EnterpriseInfrSpecMode MapToPersistenceModel(EnterpriseDomaSpecEnti enterpriseDomaSpecEnti)
		{
			EnterpriseInfrSpecMode? enterpriseInfrSpecMode = null;

			if (enterpriseDomaSpecEnti != null)
			{
				enterpriseInfrSpecMode = new EnterpriseInfrSpecMode();
				enterpriseInfrSpecMode.Id = enterpriseDomaSpecEnti.Id;
				enterpriseInfrSpecMode.Name = enterpriseDomaSpecEnti.Name;
				enterpriseInfrSpecMode.Status = enterpriseDomaSpecEnti.Status;
				enterpriseInfrSpecMode.EntrepreneurId = enterpriseDomaSpecEnti.EntrepreneurId;
				enterpriseInfrSpecMode.OperatingSegmentId = enterpriseDomaSpecEnti.OperatingSegmentId;
				enterpriseInfrSpecMode.CityId = enterpriseDomaSpecEnti.CityId;
			}

			return enterpriseInfrSpecMode;
		}

		public static EnterpriseDomaSpecEnti MapToDomainEntity(EnterpriseInfrSpecMode enterpriseInfrSpecMode)
		{
			EnterpriseDomaSpecEnti? enterpriseDomaSpecEnti = null;

			if (enterpriseInfrSpecMode != null)
			{
				enterpriseDomaSpecEnti = new EnterpriseDomaSpecEnti();
				enterpriseDomaSpecEnti.Id = enterpriseInfrSpecMode.Id;
				enterpriseDomaSpecEnti.Name = enterpriseInfrSpecMode.Name;
				enterpriseDomaSpecEnti.Status = enterpriseInfrSpecMode.Status;
				enterpriseDomaSpecEnti.EntrepreneurId = enterpriseInfrSpecMode.EntrepreneurId;
				enterpriseDomaSpecEnti.OperatingSegmentId = enterpriseInfrSpecMode.OperatingSegmentId;
				enterpriseDomaSpecEnti.CityId = enterpriseInfrSpecMode.CityId;
			}

			return enterpriseDomaSpecEnti;
		}
	}
}