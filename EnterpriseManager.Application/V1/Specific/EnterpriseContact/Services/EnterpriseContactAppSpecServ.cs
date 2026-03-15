using EnterpriseManager.Application.Specific.EnterpriseContact.Mappers;
using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Services;
using EnterpriseManager.Domain.Specific.EnterpriseContact.Entities;
using EnterpriseManager.Domain.Specific.EnterpriseContact.Entities.Validators;
using EnterpriseManager.Domain.Specific.EnterpriseContact.Repositories;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects
{
	public class EnterpriseContactAppSpecServ : IEnterpriseContactAppSpecServ
	{
		private readonly ILogger<EnterpriseContactAppSpecServ> _iLogger;

		private IEnterpriseContactDomaSpecRepo _iEnterpriseContactDomaSpecRepo;

		public EnterpriseContactAppSpecServ(
			ILogger<EnterpriseContactAppSpecServ> iLogger,
			IEnterpriseContactDomaSpecRepo iEnterpriseContactDomaSpecRepo
		)
		{
			_iLogger = iLogger;
			_iEnterpriseContactDomaSpecRepo = iEnterpriseContactDomaSpecRepo;
		}

		public async Task<EnterpriseContactAppSpecObje> GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId)
		{
			EnterpriseContactDomaSpecEnti enterpriseContactDomaSpecEnti = await _iEnterpriseContactDomaSpecRepo.GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(meanOfContactId, enterpriseId);
			EnterpriseContactDomaSpecEntiVali.CheckIfTheIfEntityExist(enterpriseContactDomaSpecEnti);
			EnterpriseContactAppSpecObje enterpriseContactAppSpecObje = EnterpriseContactApplSpecMapp.MapToApplicationObject(enterpriseContactDomaSpecEnti);
			return enterpriseContactAppSpecObje;
		}

		public async Task<IEnumerable<EnterpriseContactAppSpecObje>> GetEnterpriseContactsByEnterpriseIdAsync(long enterpriseId)
		{
			IEnumerable<EnterpriseContactDomaSpecEnti> enterpriseContactsDomaSpecEnti = await _iEnterpriseContactDomaSpecRepo.GetEnterpriseContactsByEnterpriseIdAsync(enterpriseId);
			EnterpriseContactDomaSpecEntiVali.CheckIfTheEntitiesExist(enterpriseContactsDomaSpecEnti);

			List<EnterpriseContactAppSpecObje> enterpriseContactsAppSpecObje = new List<EnterpriseContactAppSpecObje>();

			EnterpriseContactAppSpecObje? enterpriseContactAppSpecObje = null;

			foreach (EnterpriseContactDomaSpecEnti enterpriseContactDomaSpecEnti in enterpriseContactsDomaSpecEnti)
			{
				enterpriseContactAppSpecObje = EnterpriseContactApplSpecMapp.MapToApplicationObject(enterpriseContactDomaSpecEnti);
				enterpriseContactsAppSpecObje.Add(enterpriseContactAppSpecObje);
			}

			return enterpriseContactsAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateEnterpriseContactAsync(EnterpriseContactAppSpecObje? enterpriseContactAppSpecObje)
		{
			bool output = false;

			EnterpriseContactDomaSpecEnti newEnterpriseContactDomaSpecEnti = EnterpriseContactApplSpecMapp.MapToDomainEntity(enterpriseContactAppSpecObje);
			EnterpriseContactDomaSpecEnti? oldEnterpriseContactDomaSpecEnti = await _iEnterpriseContactDomaSpecRepo.GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(newEnterpriseContactDomaSpecEnti.MeanOfContactId, newEnterpriseContactDomaSpecEnti.EnterpriseId);
			EnterpriseContactDomaSpecEntiVali.CheckEntityBeforeInsertingOrUpdatingIt(newEnterpriseContactDomaSpecEnti);
			if (oldEnterpriseContactDomaSpecEnti != null)
			{
				output = await _iEnterpriseContactDomaSpecRepo.UpdateEnterpriseContactAsync(newEnterpriseContactDomaSpecEnti);
			}
			else
			{
				output = await _iEnterpriseContactDomaSpecRepo.InsertEnterpriseContactAsync(newEnterpriseContactDomaSpecEnti);
			}

			return output;
		}

		public async Task<bool> DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId)
		{
			bool output = await _iEnterpriseContactDomaSpecRepo.DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(meanOfContactId, enterpriseId);
			return output;
		}
	}
}