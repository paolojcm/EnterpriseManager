using DatabaseClient.General.Objects;

namespace EnterpriseManager.Infrastructure.Specific.City.Models
{
	public class CityInfrSpecMode
	{
		[ColumnMapping("Id")]
		public long Id { get; set; }

		[ColumnMapping("Name")]
		public string? Name { get; set; }

		[ColumnMapping("State_Id")]
		public long StateId { get; set; }
	}
}