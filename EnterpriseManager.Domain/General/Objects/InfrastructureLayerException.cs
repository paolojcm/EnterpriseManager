using System.Net;

namespace EnterpriseManager.Infrastructure.General.Objects
{
	public class InfrastructureLayerException : Exception
	{
		public HttpStatusCode HttpStatusCode;

		public InfrastructureLayerException(HttpStatusCode? httpStatusCode) : base()
		{
			if (httpStatusCode != null)
				HttpStatusCode = (HttpStatusCode)httpStatusCode;
		}

		public InfrastructureLayerException(HttpStatusCode? httpStatusCode, string? message) : base(message)
		{
			if (httpStatusCode != null)
				HttpStatusCode = (HttpStatusCode)httpStatusCode;
		}

		public InfrastructureLayerException(HttpStatusCode? httpStatusCode, string? message, Exception? innerException) : base(message, innerException)
		{
			if (httpStatusCode != null)
				HttpStatusCode = (HttpStatusCode)httpStatusCode;
		}
	}
}