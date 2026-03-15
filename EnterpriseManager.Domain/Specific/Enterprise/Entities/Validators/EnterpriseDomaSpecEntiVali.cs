using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Domain.Specific.Enterprise.Entities.Validators
{
	public class EnterpriseDomaSpecEntiVali
	{
		public static void CheckIfTheIfEntityExist(EnterpriseDomaSpecEnti? enterpriseDomaSpecEnti)
		{
			if (enterpriseDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Enterprise not found!");
		}

		public static void CheckIfTheEntitiesExist(IEnumerable<EnterpriseDomaSpecEnti>? enterprisesDomaSpecEnti)
		{
			if ((enterprisesDomaSpecEnti == null) || (enterprisesDomaSpecEnti.Count() == 0))
				throw new DomainLayerException(HttpStatusCode.NotFound, $"Enterprises not found!");
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(IEnumerable<EnterpriseDomaSpecEnti>? oldEnterprisesDomaSpecEnti, EnterpriseDomaSpecEnti newEnterpriseDomaSpecEnti)
		{
			if ((oldEnterprisesDomaSpecEnti != null) && (oldEnterprisesDomaSpecEnti.Count() > 0))
			{
				if (newEnterpriseDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEnterpriseDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newEnterpriseDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEnterpriseDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (EnterpriseDomaSpecEnti enterpriseDomaSpecEnti in oldEnterprisesDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(enterpriseDomaSpecEnti.Name))
					{
						if (enterpriseDomaSpecEnti.Name.Trim().ToLower() == newEnterpriseDomaSpecEnti.Name.Trim().ToLower())
						{
							if (enterpriseDomaSpecEnti.Id != newEnterpriseDomaSpecEnti.Id)
							{
								throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a enterprise with that name!");
							}
						}
					}
				}
			}
		}

		public static void CheckIfAnEntityAlreadyExistsBeforeInsertingIt(IEnumerable<EnterpriseDomaSpecEnti>? oldEnterprisesDomaSpecEnti, EnterpriseDomaSpecEnti newEnterpriseDomaSpecEnti)
		{
			if ((oldEnterprisesDomaSpecEnti != null) && (oldEnterprisesDomaSpecEnti.Count() > 0))
			{
				if (newEnterpriseDomaSpecEnti == null)
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEnterpriseDomaSpecEnti)}] cannot be null!");

				if (string.IsNullOrWhiteSpace(newEnterpriseDomaSpecEnti.Name))
					throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEnterpriseDomaSpecEnti.Name)}] cannot be null or empty or white space!");

				foreach (EnterpriseDomaSpecEnti enterpriseDomaSpecEnti in oldEnterprisesDomaSpecEnti)
				{
					if (!string.IsNullOrWhiteSpace(enterpriseDomaSpecEnti.Name))
					{
						if (enterpriseDomaSpecEnti.Name.Trim().ToLower() == newEnterpriseDomaSpecEnti.Name.Trim().ToLower())
						{
							throw new DomainLayerException(HttpStatusCode.InternalServerError, $"There is already a enterprise with that name!");
						}
					}
				}
			}
		}
	}
}