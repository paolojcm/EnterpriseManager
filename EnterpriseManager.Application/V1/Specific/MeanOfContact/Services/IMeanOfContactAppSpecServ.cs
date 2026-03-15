using EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects;

namespace EnterpriseManager.Application.V1.Specific.MeanOfContact.Services
{
	public interface IMeanOfContactAppSpecServ
	{
		Task<MeanOfContactAppSpecObje> GetMeanOfContactByIdAsync(long id);

		Task<IEnumerable<MeanOfContactAppSpecObje>> GetMeansOfContactByNameAsync(string? name);

		Task<bool> InsertOrUpdateMeanOfContactAsync(MeanOfContactAppSpecObje? meanOfContactAppSpecObje);

		Task<bool> DeleteMeanOfContactByIdAsync(long id);
	}
}