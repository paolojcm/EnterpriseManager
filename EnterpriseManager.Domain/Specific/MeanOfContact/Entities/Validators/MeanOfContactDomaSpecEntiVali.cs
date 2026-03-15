using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Domain.Specific.MeanOfContact.Entities.Validators
{
	public class MeanOfContactDomaSpecEntiVali
	{
		public static void CheckIfTheIfEntityExist(MeanOfContactDomaSpecEnti? meanOfContactDomaSpecEnti)
		{
			if (meanOfContactDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Mean Of Contact not found!");
		}

		public static void CheckIfTheEntitiesExist(IEnumerable<MeanOfContactDomaSpecEnti>? meansOfContactDomaSpecEnti)
		{
			if ((meansOfContactDomaSpecEnti == null) || (meansOfContactDomaSpecEnti.Count() == 0))
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Means Of Contact not found!");
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(IEnumerable<MeanOfContactDomaSpecEnti>? oldMeansOfContactDomaSpecEnti, MeanOfContactDomaSpecEnti newMeanOfContactDomaSpecEnti)
		{
			if ((oldMeansOfContactDomaSpecEnti != null) && (oldMeansOfContactDomaSpecEnti.Count() > 0))
			{
				if (newMeanOfContactDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newMeanOfContactDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newMeanOfContactDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newMeanOfContactDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (MeanOfContactDomaSpecEnti meanOfContactDomaSpecEnti in oldMeansOfContactDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(meanOfContactDomaSpecEnti.Name))
					{
						if (meanOfContactDomaSpecEnti.Name.Trim().ToLower() == newMeanOfContactDomaSpecEnti.Name.Trim().ToLower())
						{
							if (meanOfContactDomaSpecEnti.Id != newMeanOfContactDomaSpecEnti.Id)
							{
								throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a meanOfContact with that name!");
							}
						}
					}
				}
			}
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeInsertingIt(IEnumerable<MeanOfContactDomaSpecEnti>? oldMeansOfContactDomaSpecEnti, MeanOfContactDomaSpecEnti newMeanOfContactDomaSpecEnti)
		{
			if ((oldMeansOfContactDomaSpecEnti != null) && (oldMeansOfContactDomaSpecEnti.Count() > 0))
			{
				if (newMeanOfContactDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newMeanOfContactDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newMeanOfContactDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newMeanOfContactDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (MeanOfContactDomaSpecEnti meanOfContactDomaSpecEnti in oldMeansOfContactDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(meanOfContactDomaSpecEnti.Name))
					{
						if (meanOfContactDomaSpecEnti.Name.Trim().ToLower() == newMeanOfContactDomaSpecEnti.Name.Trim().ToLower())
						{
							throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a meanOfContact with that name!");
						}
					}
				}
			}
		}
	}
}