using DatabaseClient.General.Objects;

namespace EnterpriseManager.Infrastructure.Specific.Country.Models
{
	public class CountryInfrSpecMode
	{
		[ColumnMapping("Id")]
		public long Id { get; set; }

		[ColumnMapping("Name")]
		public string? Name { get; set; }
	}
}