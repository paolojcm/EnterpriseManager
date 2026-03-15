using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Domain.Specific.OperatingSegment.Entities.Validators
{
	public class OperatingSegmentDomaSpecEntiVali
	{
		public static void CheckIfTheIfEntityExist(OperatingSegmentDomaSpecEnti? operatingSegmentDomaSpecEnti)
		{
			if (operatingSegmentDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Operating Segment not found!");
		}

		public static void CheckIfTheEntitiesExist(IEnumerable<OperatingSegmentDomaSpecEnti>? operatingSegmentsDomaSpecEnti)
		{
			if ((operatingSegmentsDomaSpecEnti == null) || (operatingSegmentsDomaSpecEnti.Count() == 0))
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Operating Segments not found!");
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(IEnumerable<OperatingSegmentDomaSpecEnti>? oldOperatingSegmentsDomaSpecEnti, OperatingSegmentDomaSpecEnti newOperatingSegmentDomaSpecEnti)
		{
			if ((oldOperatingSegmentsDomaSpecEnti != null) && (oldOperatingSegmentsDomaSpecEnti.Count() > 0))
			{
				if (newOperatingSegmentDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newOperatingSegmentDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newOperatingSegmentDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newOperatingSegmentDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (OperatingSegmentDomaSpecEnti operatingSegmentDomaSpecEnti in oldOperatingSegmentsDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(operatingSegmentDomaSpecEnti.Name))
					{
						if (operatingSegmentDomaSpecEnti.Name.Trim().ToLower() == newOperatingSegmentDomaSpecEnti.Name.Trim().ToLower())
						{
							if (operatingSegmentDomaSpecEnti.Id != newOperatingSegmentDomaSpecEnti.Id)
							{
								throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a operatingSegment with that name!");
							}
						}
					}
				}
			}
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeInsertingIt(IEnumerable<OperatingSegmentDomaSpecEnti>? oldOperatingSegmentsDomaSpecEnti, OperatingSegmentDomaSpecEnti newOperatingSegmentDomaSpecEnti)
		{
			if ((oldOperatingSegmentsDomaSpecEnti != null) && (oldOperatingSegmentsDomaSpecEnti.Count() > 0))
			{
				if (newOperatingSegmentDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newOperatingSegmentDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newOperatingSegmentDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newOperatingSegmentDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (OperatingSegmentDomaSpecEnti operatingSegmentDomaSpecEnti in oldOperatingSegmentsDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(operatingSegmentDomaSpecEnti.Name))
					{
						if (operatingSegmentDomaSpecEnti.Name.Trim().ToLower() == newOperatingSegmentDomaSpecEnti.Name.Trim().ToLower())
						{
							throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a operatingSegment with that name!");
						}
					}
				}
			}
		}
	}
}