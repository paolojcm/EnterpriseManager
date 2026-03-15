namespace EnterpriseManager.Domain.General.Objects
{
	public class ActionResultObject
	{
		public bool Status { get; set; }

		public string? Type { get; set; }

		public object? Message { get; set; }
	}
}
