using EnterpriseManager.Application.Specific.Entrepreneur.Mappers;
using EnterpriseManager.Application.V1.Specific.Entrepreneur.Services;
using EnterpriseManager.Domain.Specific.Entrepreneur.Entities;
using EnterpriseManager.Domain.Specific.Entrepreneur.Entities.Validators;
using EnterpriseManager.Domain.Specific.Entrepreneur.Repositories;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects
{
	public class EntrepreneurAppSpecServ : IEntrepreneurAppSpecServ
	{
		private readonly ILogger<EntrepreneurAppSpecServ> _iLogger;

		private IEntrepreneurDomaSpecRepo _iEntrepreneurDomaSpecRepo;

		public EntrepreneurAppSpecServ(
			ILogger<EntrepreneurAppSpecServ> iLogger,
			IEntrepreneurDomaSpecRepo iEntrepreneurDomaSpecRepo
		)
		{
			_iLogger = iLogger;
			_iEntrepreneurDomaSpecRepo = iEntrepreneurDomaSpecRepo;
		}

		public async Task<EntrepreneurAppSpecObje> GetEntrepreneurByIdAsync(long id)
		{
			EntrepreneurDomaSpecEnti entrepreneurDomaSpecEnti = await _iEntrepreneurDomaSpecRepo.GetEntrepreneurByIdAsync(id);
			EntrepreneurDomaSpecEntiVali.CheckIfTheIfEntityExist(entrepreneurDomaSpecEnti);
			EntrepreneurAppSpecObje entrepreneurAppSpecObje = EntrepreneurApplSpecMapp.MapToApplicationObject(entrepreneurDomaSpecEnti);
			return entrepreneurAppSpecObje;
		}

		public async Task<IEnumerable<EntrepreneurAppSpecObje>> GetEntrepreneursByNameAsync(string? name)
		{
			IEnumerable<EntrepreneurDomaSpecEnti> entrepreneursDomaSpecEnti = await _iEntrepreneurDomaSpecRepo.GetEntrepreneursByNameAsync(name);
			EntrepreneurDomaSpecEntiVali.CheckIfTheEntitiesExist(entrepreneursDomaSpecEnti);

			List<EntrepreneurAppSpecObje> entrepreneursAppSpecObje = new List<EntrepreneurAppSpecObje>();

			EntrepreneurAppSpecObje? entrepreneurAppSpecObje = null;

			foreach (EntrepreneurDomaSpecEnti entrepreneurDomaSpecEnti in entrepreneursDomaSpecEnti)
			{
				entrepreneurAppSpecObje = EntrepreneurApplSpecMapp.MapToApplicationObject(entrepreneurDomaSpecEnti);
				entrepreneursAppSpecObje.Add(entrepreneurAppSpecObje);
			}

			return entrepreneursAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateEntrepreneurAsync(EntrepreneurAppSpecObje? entrepreneurAppSpecObje)
		{
			EntrepreneurDomaSpecEnti newEntrepreneurDomaSpecEnti = EntrepreneurApplSpecMapp.MapToDomainEntity(entrepreneurAppSpecObje);
			IEnumerable<EntrepreneurDomaSpecEnti>? oldEntrepreneursDomaSpecEnti = await _iEntrepreneurDomaSpecRepo.GetEntrepreneursByNameAsync(newEntrepreneurDomaSpecEnti.Name);
			if (newEntrepreneurDomaSpecEnti.Id > 0)
			{
				EntrepreneurDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(oldEntrepreneursDomaSpecEnti, newEntrepreneurDomaSpecEnti);
			}
			else
			{
				EntrepreneurDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeInsertingIt(oldEntrepreneursDomaSpecEnti, newEntrepreneurDomaSpecEnti);
			}

			return await _iEntrepreneurDomaSpecRepo.InsertOrUpdateEntrepreneurAsync(newEntrepreneurDomaSpecEnti);
		}

		public async Task<bool> DeleteEntrepreneurByIdAsync(long id)
		{
			bool output = await _iEntrepreneurDomaSpecRepo.DeleteEntrepreneurByIdAsync(id);
			return output;
		}
	}
}