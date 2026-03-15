using DatabaseClient.General.Objects;

namespace EnterpriseManager.Infrastructure.Specific.State.Models
{
	public class StateInfrSpecMode
	{
		[ColumnMapping("Id")]
		public long Id { get; set; }

		[ColumnMapping("Acronym")]
		public string? Acronym { get; set; }

		[ColumnMapping("Name")]
		public string? Name { get; set; }

		[ColumnMapping("Country_Id")]
		public long CountryId { get; set; }
	}
}