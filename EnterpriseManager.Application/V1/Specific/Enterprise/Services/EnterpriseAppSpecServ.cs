using EnterpriseManager.Application.Specific.Enterprise.Mappers;
using EnterpriseManager.Application.V1.Specific.Enterprise.Services;
using EnterpriseManager.Domain.Specific.Enterprise.Entities;
using EnterpriseManager.Domain.Specific.Enterprise.Entities.Validators;
using EnterpriseManager.Domain.Specific.Enterprise.Repositories;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.Enterprise.Objects
{
	public class EnterpriseAppSpecServ : IEnterpriseAppSpecServ
	{
		private readonly ILogger<EnterpriseAppSpecServ> _iLogger;

		private IEnterpriseDomaSpecRepo _iEnterpriseDomaSpecRepo;

		public EnterpriseAppSpecServ(
			ILogger<EnterpriseAppSpecServ> iLogger,
			IEnterpriseDomaSpecRepo iEnterpriseDomaSpecRepo
		)
		{
			_iLogger = iLogger;
			_iEnterpriseDomaSpecRepo = iEnterpriseDomaSpecRepo;
		}

		public async Task<EnterpriseAppSpecObje> GetEnterpriseByIdAsync(long id)
		{
			EnterpriseDomaSpecEnti enterpriseDomaSpecEnti = await _iEnterpriseDomaSpecRepo.GetEnterpriseByIdAsync(id);
			EnterpriseDomaSpecEntiVali.CheckIfTheIfEntityExist(enterpriseDomaSpecEnti);
			EnterpriseAppSpecObje enterpriseAppSpecObje = EnterpriseApplSpecMapp.MapToApplicationObject(enterpriseDomaSpecEnti);
			return enterpriseAppSpecObje;
		}

		public async Task<IEnumerable<EnterpriseAppSpecObje>> GetEnterprisesByNameAsync(string? name)
		{
			IEnumerable<EnterpriseDomaSpecEnti> enterprisesDomaSpecEnti = await _iEnterpriseDomaSpecRepo.GetEnterprisesByNameAsync(name);
			EnterpriseDomaSpecEntiVali.CheckIfTheEntitiesExist(enterprisesDomaSpecEnti);

			List<EnterpriseAppSpecObje> enterprisesAppSpecObje = new List<EnterpriseAppSpecObje>();

			EnterpriseAppSpecObje? enterpriseAppSpecObje = null;

			foreach (EnterpriseDomaSpecEnti enterpriseDomaSpecEnti in enterprisesDomaSpecEnti)
			{
				enterpriseAppSpecObje = EnterpriseApplSpecMapp.MapToApplicationObject(enterpriseDomaSpecEnti);
				enterprisesAppSpecObje.Add(enterpriseAppSpecObje);
			}

			return enterprisesAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateEnterpriseAsync(EnterpriseAppSpecObje? enterpriseAppSpecObje)
		{
			EnterpriseDomaSpecEnti newEnterpriseDomaSpecEnti = EnterpriseApplSpecMapp.MapToDomainEntity(enterpriseAppSpecObje);
			IEnumerable<EnterpriseDomaSpecEnti>? oldEnterprisesDomaSpecEnti = await _iEnterpriseDomaSpecRepo.GetEnterprisesByNameAsync(newEnterpriseDomaSpecEnti.Name);
			if (newEnterpriseDomaSpecEnti.Id > 0)
			{
				EnterpriseDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(oldEnterprisesDomaSpecEnti, newEnterpriseDomaSpecEnti);
			}
			else
			{
				EnterpriseDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeInsertingIt(oldEnterprisesDomaSpecEnti, newEnterpriseDomaSpecEnti);
			}

			return await _iEnterpriseDomaSpecRepo.InsertOrUpdateEnterpriseAsync(newEnterpriseDomaSpecEnti);
		}

		public async Task<bool> DeleteEnterpriseByIdAsync(long id)
		{
			bool output = await _iEnterpriseDomaSpecRepo.DeleteEnterpriseByIdAsync(id);
			return output;
		}
	}
}