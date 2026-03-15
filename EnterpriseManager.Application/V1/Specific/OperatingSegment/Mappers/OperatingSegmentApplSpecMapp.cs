using EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects;
using EnterpriseManager.Application.V1.Specific.State.Objects;
using EnterpriseManager.Domain.Specific.OperatingSegment.Entities;

namespace EnterpriseManager.Application.Specific.OperatingSegment.Mappers
{
	public class OperatingSegmentApplSpecMapp
	{
		public static OperatingSegmentAppSpecObje MapToApplicationObject(OperatingSegmentDomaSpecEnti? operatingSegmentDomaSpecEnti)
		{
			OperatingSegmentAppSpecObje? operatingSegmentAppSpecObje = null;

			if (operatingSegmentDomaSpecEnti != null)
			{
				operatingSegmentAppSpecObje = new OperatingSegmentAppSpecObje();
				operatingSegmentAppSpecObje.Id = operatingSegmentDomaSpecEnti.Id;
				operatingSegmentAppSpecObje.Name = operatingSegmentDomaSpecEnti.Name;
			}

			return operatingSegmentAppSpecObje;
		}

		public static OperatingSegmentDomaSpecEnti MapToDomainEntity(OperatingSegmentAppSpecObje? operatingSegmentAppSpecObje)
		{
			OperatingSegmentDomaSpecEnti? operatingSegmentDomaSpecEnti = null;

			if (operatingSegmentAppSpecObje != null)
			{
				operatingSegmentDomaSpecEnti = new OperatingSegmentDomaSpecEnti();
				operatingSegmentDomaSpecEnti.Id = operatingSegmentAppSpecObje.Id;
				operatingSegmentDomaSpecEnti.Name = operatingSegmentAppSpecObje.Name;
			}

			return operatingSegmentDomaSpecEnti;
		}
	}
}