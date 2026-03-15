using DatabaseClient.General.Objects;

namespace EnterpriseManager.Infrastructure.Specific.Entrepreneur.Models
{
	public class EntrepreneurInfrSpecMode
	{
		[ColumnMapping("Id")]
		public long Id { get; set; }

		[ColumnMapping("Name")]
		public string? Name { get; set; }
	}
}