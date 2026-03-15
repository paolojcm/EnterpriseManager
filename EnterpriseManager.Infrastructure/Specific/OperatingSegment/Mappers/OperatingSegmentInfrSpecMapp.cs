using EnterpriseManager.Domain.Specific.OperatingSegment.Entities;
using EnterpriseManager.Infrastructure.Specific.OperatingSegment.Models;
using EnterpriseManager.Infrastructure.Specific.MeanOfContact.Models;

namespace EnterpriseManager.Infrastructure.Specific.OperatingSegment.Mappers
{
	public class OperatingSegmentInfrSpecMapp
	{
		public static OperatingSegmentInfrSpecMode MapToPersistenceModel(OperatingSegmentDomaSpecEnti operatingSegmentDomaSpecEnti)
		{
			OperatingSegmentInfrSpecMode? operatingSegmentInfrSpecMode = null;

			if (operatingSegmentDomaSpecEnti != null)
			{
				operatingSegmentInfrSpecMode = new OperatingSegmentInfrSpecMode();
				operatingSegmentInfrSpecMode.Id = operatingSegmentDomaSpecEnti.Id;
				operatingSegmentInfrSpecMode.Name = operatingSegmentDomaSpecEnti.Name;
			}

			return operatingSegmentInfrSpecMode;
		}

		public static OperatingSegmentDomaSpecEnti MapToDomainEntity(OperatingSegmentInfrSpecMode operatingSegmentInfrSpecMode)
		{
			OperatingSegmentDomaSpecEnti? operatingSegmentDomaSpecEnti = null;

			if (operatingSegmentInfrSpecMode != null)
			{
				operatingSegmentDomaSpecEnti = new OperatingSegmentDomaSpecEnti();
				operatingSegmentDomaSpecEnti.Id = operatingSegmentInfrSpecMode.Id;
				operatingSegmentDomaSpecEnti.Name = operatingSegmentInfrSpecMode.Name;
			}

			return operatingSegmentDomaSpecEnti;
		}
	}
}