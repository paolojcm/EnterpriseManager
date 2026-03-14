namespace EnterpriseManager.API
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			Engine engine = new Engine();
			await engine.StartAsync(args);
		}
	}
}