using DatabaseClient.General.Objects;

namespace EnterpriseManager.Infrastructure.Specific.OperatingSegment.Models
{
	public class OperatingSegmentInfrSpecMode
	{
		[ColumnMapping("Id")]
		public long Id { get; set; }

		[ColumnMapping("Name")]
		public string? Name { get; set; }
	}
}