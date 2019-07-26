using aspnetcore_custom_config_sample.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreCustomConfigSample
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration(AddRedisConfiguration)
				.UseUrls("http://localhost:5000")
				.UseStartup<Startup>()
				.Build();

		private static void AddRedisConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
		{
			var configuration = builder.Build();
			builder.AddRedisConfiguration("localhost");
		}
	}
}
