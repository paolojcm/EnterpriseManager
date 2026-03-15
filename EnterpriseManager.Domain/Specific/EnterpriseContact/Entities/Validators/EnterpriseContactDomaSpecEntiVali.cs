using EnterpriseManager.Domain.General.Objects;
using System.Net;

namespace EnterpriseManager.Domain.Specific.EnterpriseContact.Entities.Validators
{
	public class EnterpriseContactDomaSpecEntiVali
	{
		public static void CheckIfTheIfEntityExist(EnterpriseContactDomaSpecEnti? enterpriseContactDomaSpecEnti)
		{
			if (enterpriseContactDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.NotFound, $"EnterpriseContact not found!");
		}

		public static void CheckIfTheEntitiesExist(IEnumerable<EnterpriseContactDomaSpecEnti>? enterpriseContactsDomaSpecEnti)
		{
			if ((enterpriseContactsDomaSpecEnti == null) || (enterpriseContactsDomaSpecEnti.Count() == 0))
				throw new DomainLayerException(HttpStatusCode.NotFound, $"EnterpriseContacts not found!");
		}

		public static void CheckEntityBeforeInsertingOrUpdatingIt(EnterpriseContactDomaSpecEnti newEnterpriseContactDomaSpecEnti)
		{
			if (newEnterpriseContactDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEnterpriseContactDomaSpecEnti)}] cannot be null!");


			if (newEnterpriseContactDomaSpecEnti == null)
				throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEnterpriseContactDomaSpecEnti)}] cannot be null!");

			if (newEnterpriseContactDomaSpecEnti.MeanOfContactId <= 0)
				throw new Exception($"The {{field}} [{nameof(newEnterpriseContactDomaSpecEnti.MeanOfContactId)}] cannot be less than or equals to 0!");

			if (newEnterpriseContactDomaSpecEnti.EnterpriseId <= 0)
				throw new Exception($"The {{field}} [{nameof(newEnterpriseContactDomaSpecEnti.EnterpriseId)}] cannot be less than or equals to 0!");

			if (string.IsNullOrWhiteSpace(newEnterpriseContactDomaSpecEnti.Contents))
				throw new DomainLayerException(HttpStatusCode.InternalServerError, $"The {{field}} [{nameof(newEnterpriseContactDomaSpecEnti.Contents)}] cannot be null or empty or white space!");
		}
	}
}