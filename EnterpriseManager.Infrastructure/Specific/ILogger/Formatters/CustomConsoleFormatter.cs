using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;

namespace EnterpriseManager.Infrastructure.Specific.ILogger.Formatters
{
	public class CustomConsoleFormatter : ConsoleFormatter
	{
		public CustomConsoleFormatter() : base("CustomConsoleFormatter")
		{
		}

		public override void Write<TState>(
			in LogEntry<TState> logEntry,
			IExternalScopeProvider? scopeProvider,
			TextWriter textWriter)
		{
			string? message = null;

			if (logEntry.Formatter != null)
			{
				message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception);
			}

			if (message == null)
				return;

			string dateAndTimeInTextFormat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

			textWriter.WriteLine($"{dateAndTimeInTextFormat} [{logEntry.LogLevel}] {message}");
		}
	}
}