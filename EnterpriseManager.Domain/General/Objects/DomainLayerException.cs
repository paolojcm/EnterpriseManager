using System.Net;

namespace EnterpriseManager.Domain.General.Objects
{
	public class DomainLayerException : Exception
	{
		public HttpStatusCode HttpStatusCode;

		public DomainLayerException(HttpStatusCode? httpStatusCode) : base()
		{
			if (httpStatusCode != null)
				HttpStatusCode = (HttpStatusCode)httpStatusCode;
		}

		public DomainLayerException(HttpStatusCode? httpStatusCode, string? message) : base(message)
		{
			if (httpStatusCode != null)
				HttpStatusCode = (HttpStatusCode)httpStatusCode;
		}

		public DomainLayerException(HttpStatusCode? httpStatusCode, string? message, Exception? innerException) : base(message, innerException)
		{
			if (httpStatusCode != null)
				HttpStatusCode = (HttpStatusCode)httpStatusCode;
		}
	}
}