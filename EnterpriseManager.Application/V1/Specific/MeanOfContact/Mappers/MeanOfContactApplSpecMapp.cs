using EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects;
using EnterpriseManager.Application.V1.Specific.State.Objects;
using EnterpriseManager.Domain.Specific.MeanOfContact.Entities;

namespace EnterpriseManager.Application.Specific.MeanOfContact.Mappers
{
	public class MeanOfContactApplSpecMapp
	{
		public static MeanOfContactAppSpecObje MapToApplicationObject(MeanOfContactDomaSpecEnti? meanOfContactDomaSpecEnti)
		{
			MeanOfContactAppSpecObje? meanOfContactAppSpecObje = null;

			if (meanOfContactDomaSpecEnti != null)
			{
				meanOfContactAppSpecObje = new MeanOfContactAppSpecObje();
				meanOfContactAppSpecObje.Id = meanOfContactDomaSpecEnti.Id;
				meanOfContactAppSpecObje.Name = meanOfContactDomaSpecEnti.Name;
			}

			return meanOfContactAppSpecObje;
		}

		public static MeanOfContactDomaSpecEnti MapToDomainEntity(MeanOfContactAppSpecObje? meanOfContactAppSpecObje)
		{
			MeanOfContactDomaSpecEnti? meanOfContactDomaSpecEnti = null;

			if (meanOfContactAppSpecObje != null)
			{
				meanOfContactDomaSpecEnti = new MeanOfContactDomaSpecEnti();
				meanOfContactDomaSpecEnti.Id = meanOfContactAppSpecObje.Id;
				meanOfContactDomaSpecEnti.Name = meanOfContactAppSpecObje.Name;
			}

			return meanOfContactDomaSpecEnti;
		}
	}
}