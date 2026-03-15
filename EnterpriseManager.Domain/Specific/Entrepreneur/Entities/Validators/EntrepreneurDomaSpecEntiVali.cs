using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Domain.Specific.Entrepreneur.Entities.Validators
{
	public class EntrepreneurDomaSpecEntiVali
	{
		public static void CheckIfTheIfEntityExist(EntrepreneurDomaSpecEnti? entrepreneurDomaSpecEnti)
		{
			if (entrepreneurDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Entrepreneur not found!");
		}

		public static void CheckIfTheEntitiesExist(IEnumerable<EntrepreneurDomaSpecEnti>? entrepreneursDomaSpecEnti)
		{
			if ((entrepreneursDomaSpecEnti == null) || (entrepreneursDomaSpecEnti.Count() == 0))
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Entrepreneurs not found!");
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(IEnumerable<EntrepreneurDomaSpecEnti>? oldEntrepreneursDomaSpecEnti, EntrepreneurDomaSpecEnti newEntrepreneurDomaSpecEnti)
		{
			if ((oldEntrepreneursDomaSpecEnti != null) && (oldEntrepreneursDomaSpecEnti.Count() > 0))
			{
				if (newEntrepreneurDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEntrepreneurDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newEntrepreneurDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEntrepreneurDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (EntrepreneurDomaSpecEnti entrepreneurDomaSpecEnti in oldEntrepreneursDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(entrepreneurDomaSpecEnti.Name))
					{
						if (entrepreneurDomaSpecEnti.Name.Trim().ToLower() == newEntrepreneurDomaSpecEnti.Name.Trim().ToLower())
						{
							if (entrepreneurDomaSpecEnti.Id != newEntrepreneurDomaSpecEnti.Id)
							{
								throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a entrepreneur with that name!");
							}
						}
					}
				}
			}
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeInsertingIt(IEnumerable<EntrepreneurDomaSpecEnti>? oldEntrepreneursDomaSpecEnti, EntrepreneurDomaSpecEnti newEntrepreneurDomaSpecEnti)
		{
			if ((oldEntrepreneursDomaSpecEnti != null) && (oldEntrepreneursDomaSpecEnti.Count() > 0))
			{
				if (newEntrepreneurDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEntrepreneurDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newEntrepreneurDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEntrepreneurDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (EntrepreneurDomaSpecEnti entrepreneurDomaSpecEnti in oldEntrepreneursDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(entrepreneurDomaSpecEnti.Name))
					{
						if (entrepreneurDomaSpecEnti.Name.Trim().ToLower() == newEntrepreneurDomaSpecEnti.Name.Trim().ToLower())
						{
							throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a entrepreneur with that name!");
						}
					}
				}
			}
		}
	}
}