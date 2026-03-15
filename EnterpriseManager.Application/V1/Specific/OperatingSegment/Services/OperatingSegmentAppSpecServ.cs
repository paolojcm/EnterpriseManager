using EnterpriseManager.Application.Specific.OperatingSegment.Mappers;
using EnterpriseManager.Application.V1.Specific.OperatingSegment.Services;
using EnterpriseManager.Domain.Specific.OperatingSegment.Entities;
using EnterpriseManager.Domain.Specific.OperatingSegment.Entities.Validators;
using EnterpriseManager.Domain.Specific.OperatingSegment.Repositories;
using Microsoft.Extensions.Logging;

namespace EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects
{
	public class OperatingSegmentAppSpecServ : IOperatingSegmentAppSpecServ
	{
		private readonly ILogger<OperatingSegmentAppSpecServ> _iLogger;

		private IOperatingSegmentDomaSpecRepo _iOperatingSegmentDomaSpecRepo;

		public OperatingSegmentAppSpecServ(
			ILogger<OperatingSegmentAppSpecServ> iLogger,
			IOperatingSegmentDomaSpecRepo iOperatingSegmentDomaSpecRepo
		)
		{
			_iLogger = iLogger;
			_iOperatingSegmentDomaSpecRepo = iOperatingSegmentDomaSpecRepo;
		}

		public async Task<OperatingSegmentAppSpecObje> GetOperatingSegmentByIdAsync(long id)
		{
			OperatingSegmentDomaSpecEnti operatingSegmentDomaSpecEnti = await _iOperatingSegmentDomaSpecRepo.GetOperatingSegmentByIdAsync(id);
			OperatingSegmentDomaSpecEntiVali.CheckIfTheIfEntityExist(operatingSegmentDomaSpecEnti);
			OperatingSegmentAppSpecObje operatingSegmentAppSpecObje = OperatingSegmentApplSpecMapp.MapToApplicationObject(operatingSegmentDomaSpecEnti);
			return operatingSegmentAppSpecObje;
		}

		public async Task<IEnumerable<OperatingSegmentAppSpecObje>> GetOperatingSegmentsByNameAsync(string? name)
		{
			IEnumerable<OperatingSegmentDomaSpecEnti> operatingSegmentsDomaSpecEnti = await _iOperatingSegmentDomaSpecRepo.GetOperatingSegmentsByNameAsync(name);
			OperatingSegmentDomaSpecEntiVali.CheckIfTheEntitiesExist(operatingSegmentsDomaSpecEnti);

			List<OperatingSegmentAppSpecObje> operatingSegmentsAppSpecObje = new List<OperatingSegmentAppSpecObje>();

			OperatingSegmentAppSpecObje? operatingSegmentAppSpecObje = null;

			foreach (OperatingSegmentDomaSpecEnti operatingSegmentDomaSpecEnti in operatingSegmentsDomaSpecEnti)
			{
				operatingSegmentAppSpecObje = OperatingSegmentApplSpecMapp.MapToApplicationObject(operatingSegmentDomaSpecEnti);
				operatingSegmentsAppSpecObje.Add(operatingSegmentAppSpecObje);
			}

			return operatingSegmentsAppSpecObje;
		}

		public async Task<bool> InsertOrUpdateOperatingSegmentAsync(OperatingSegmentAppSpecObje? operatingSegmentAppSpecObje)
		{
			OperatingSegmentDomaSpecEnti newOperatingSegmentDomaSpecEnti = OperatingSegmentApplSpecMapp.MapToDomainEntity(operatingSegmentAppSpecObje);
			IEnumerable<OperatingSegmentDomaSpecEnti>? oldOperatingSegmentsDomaSpecEnti = await _iOperatingSegmentDomaSpecRepo.GetOperatingSegmentsByNameAsync(newOperatingSegmentDomaSpecEnti.Name);
			if (newOperatingSegmentDomaSpecEnti.Id > 0)
			{
				OperatingSegmentDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeUpdatingIt(oldOperatingSegmentsDomaSpecEnti, newOperatingSegmentDomaSpecEnti);
			}
			else
			{
				OperatingSegmentDomaSpecEntiVali.CheckIfAnEntityAlreadyExistsBeforeInsertingIt(oldOperatingSegmentsDomaSpecEnti, newOperatingSegmentDomaSpecEnti);
			}

			return await _iOperatingSegmentDomaSpecRepo.InsertOrUpdateOperatingSegmentAsync(newOperatingSegmentDomaSpecEnti);
		}

		public async Task<bool> DeleteOperatingSegmentByIdAsync(long id)
		{
			bool output = await _iOperatingSegmentDomaSpecRepo.DeleteOperatingSegmentByIdAsync(id);
			return output;
		}
	}
}