using DatabaseClient.General.Objects;

namespace EnterpriseManager.Infrastructure.Specific.EnterpriseContact.Models
{
	public class EnterpriseContactInfrSpecMode
	{
		[ColumnMapping("Mean_Of_Contact_Id")]
		public long MeanOfContactId { get; set; }

		[ColumnMapping("Enterprise_Id")]
		public long EnterpriseId { get; set; }

		[ColumnMapping("Contents")]
		public string? Contents { get; set; }
	}
}