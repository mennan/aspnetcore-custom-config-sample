using aspnetcore_custom_config_sample.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace aspnetcore_custom_config_sample.Configuration
{
	public class RedisConfigurationProvider : ConfigurationProvider
	{
		private readonly string _redisHost;

		public RedisConfigurationProvider(string redisHost)
		{
			_redisHost = redisHost;
		}

		public override void Load()
		{
			var options = ConfigurationOptions.Parse(_redisHost);
			var connectionMultiplexer = ConnectionMultiplexer.Connect(options);
			var redisSettings = connectionMultiplexer.GetDatabase().StringGet("Settings");
			var settings = JsonConvert.DeserializeObject<AppSettings>(redisSettings);

			Data.Add("AppName", settings.AppName);
			Data.Add("AppVersion", settings.AppVersion);
		}
	}
}