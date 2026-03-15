using EnterpriseManager.Application.Specific.MeanOfContact.Mappers;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.Services;
using EnterpriseManager.Domain.Specific.MeanOfContact.Entities;
using EnterpriseManager.Domain.Specific.MeanOfContact.Entities.Validators;
using EnterpriseManager.Domain.Specific.MeanOfContact.Repositories;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects
{
	public class MeanOfContactAppSpecServ : IMeanOfContactAppSpecServ
	{
		private readonly ILogger<MeanOfContactAppSpecServ> _iLogger;

		private IMeanOfContactDomaSpecRepo _iMeanOfContactDomaSpecRepo;

		public MeanOfContactAppSpecServ(
			ILogger<MeanOfContactAppSpecServ> iLogger,
			IMeanOfContactDomaSpecRepo iMeanOfContactDomaSpecRepo
		)
		{
			_iLogger = iLogger;
			_iMeanOfContactDomaSpecRepo = iMeanOfContactDomaSpecRepo;
		}

		public async Task<MeanOfContactAppSpecObje> GetMeanOfContactByIdAsync(long id)
		{
			MeanOfContactDomaSpecEnti meanOfContactDomaSpecEnti = await _iMeanOfContactDomaSpecRepo.GetMeanOfContactByIdAsync(id);
			MeanOfContactDomaSpecEntiVali.CheckIfTheIfEntityExist(meanOfContactDomaSpecEnti);
			MeanOfContactAppSpecObje meanOfContactAppSpecObje = MeanOfContactApplSpecMapp.MapToApplicationObject(meanOfContactDomaSpecEnti);
			return meanOfContactAppSpecObje;
		}

		public async Task<IEnumerable<MeanOfContactAppSpecObje>> GetMeansOfContactByNameAsync(string? name)
		{
			IEnumerable<MeanOfContactDomaSpecEnti> meansOfContactDomaSpecEnti = await _iMeanOfContactDomaSpecRepo.GetMeansOfContactByNameAsync(name);
			MeanOfContactDomaSpecEntiVali.CheckIfTheEntitiesExist(meansOfContactDomaSpecEnti);

			List<MeanOfContactAppSpecObje> meansOfContactAppSpecObje = new List<MeanOfContactAppSpecObje>();

			MeanOfContactAppSpecObje? meanOfContactAppSpecObje = null;

			foreach (MeanOfContactDomaSpecEnti meanOfContactDomaSpecEnti in meansOfContactDomaSpecEnti)
			{
				meanOfContactAppSpecObje = MeanOfContactApplSpecMapp.MapToApplicationObject(meanOfContactDomaSpecEnti);
				meansOfContactAppSpecObje.Add(meanOfContactAppSpecObje);
			}

			return meansOfContactAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateMeanOfContactAsync(MeanOfContactAppSpecObje? meanOfContactAppSpecObje)
		{
			MeanOfContactDomaSpecEnti newMeanOfContactDomaSpecEnti = MeanOfContactApplSpecMapp.MapToDomainEntity(meanOfContactAppSpecObje);
			IEnumerable<MeanOfContactDomaSpecEnti>? oldMeansOfContactDomaSpecEnti = await _iMeanOfContactDomaSpecRepo.GetMeansOfContactByNameAsync(newMeanOfContactDomaSpecEnti.Name);
			if (newMeanOfContactDomaSpecEnti.Id > 0)
			{
				MeanOfContactDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(oldMeansOfContactDomaSpecEnti, newMeanOfContactDomaSpecEnti);
			}
			else
			{
				MeanOfContactDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeInsertingIt(oldMeansOfContactDomaSpecEnti, newMeanOfContactDomaSpecEnti);
			}

			return await _iMeanOfContactDomaSpecRepo.InsertOrUpdateMeanOfContactAsync(newMeanOfContactDomaSpecEnti);
		}

		public async Task<bool> DeleteMeanOfContactByIdAsync(long id)
		{
			bool output = await _iMeanOfContactDomaSpecRepo.DeleteMeanOfContactByIdAsync(id);
			return output;
		}
	}
}