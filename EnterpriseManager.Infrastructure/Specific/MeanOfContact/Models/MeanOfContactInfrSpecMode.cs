using DatabaseClient.General.Objects;

namespace EnterpriseManager.Infrastructure.Specific.MeanOfContact.Models
{
	public class MeanOfContactInfrSpecMode
	{
		[ColumnMapping("Id")]
		public long Id { get; set; }

		[ColumnMapping("Name")]
		public string? Name { get; set; }
	}
}