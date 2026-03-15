using System.Net;

namespace EnterpriseManager.Application.V1.General
{
	public class ApplicationLayerException : Exception
	{
		public HttpStatusCode HttpStatusCode;

		public ApplicationLayerException(HttpStatusCode? httpStatusCode) : base() {
			if (httpStatusCode != null)
				HttpStatusCode = (HttpStatusCode)httpStatusCode;
		}

		public ApplicationLayerException(HttpStatusCode? httpStatusCode, string? message) : base(message) {
			if (httpStatusCode != null)
				HttpStatusCode = (HttpStatusCode)httpStatusCode;
		}
		
		public ApplicationLayerException(HttpStatusCode? httpStatusCode, string? message, Exception? innerException) : base(message, innerException) {
			if (httpStatusCode != null)
				HttpStatusCode = (HttpStatusCode)httpStatusCode;
		}
	}
}