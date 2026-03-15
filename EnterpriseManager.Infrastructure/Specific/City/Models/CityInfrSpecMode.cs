using DatabaseClient.General.Objects;

namespace EnterpriseManager.Infrastructure.Specific.City.Models
{
	public class CityInfrSpecMode
	{
		[ColumnMapping("Id")]
		public long Id { get; set; }

		[ColumnMapping("Name")]
		public string? Name { get; set; }

		[ColumnMapping("StateId")]
		public long StateId { get; set; }
	}
}