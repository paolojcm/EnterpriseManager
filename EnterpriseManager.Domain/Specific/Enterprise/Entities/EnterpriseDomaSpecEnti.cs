namespace EnterpriseManager.Domain.Specific.Enterprise.Entities
{
	public class EnterpriseDomaSpecEnti
	{
		public long Id { get; set; }

		public string? Name { get; set; }

		public byte Status { get; set; }

		public long EntrepreneurId { get; set; }

		public long OperatingSegmentId { get; set; }

		public long CityId { get; set; }
	}
}