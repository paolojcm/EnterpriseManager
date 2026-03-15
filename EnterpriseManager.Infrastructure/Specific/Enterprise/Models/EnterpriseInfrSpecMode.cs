using DatabaseClient.General.Objects;

namespace EnterpriseManager.Infrastructure.Specific.Enterprise.Models
{
	public class EnterpriseInfrSpecMode
	{
		[ColumnMapping("Id")]
		public long Id { get; set; }

		[ColumnMapping("Name")]
		public string? Name { get; set; }

		[ColumnMapping("Status")]
		public byte Status { get; set; }

		[ColumnMapping("Entrepreneur_Id")]
		public long EntrepreneurId { get; set; }

		[ColumnMapping("Operating_Segment_Id")]
		public long OperatingSegmentId { get; set; }

		[ColumnMapping("City_Id")]
		public long CityId { get; set; }
	}
}