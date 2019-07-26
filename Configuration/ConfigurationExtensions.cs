using Microsoft.Extensions.Configuration;

namespace aspnetcore_custom_config_sample.Configuration
{
	public static class ConfigurationExtensions
	{
		public static IConfigurationBuilder AddRedisConfiguration(this IConfigurationBuilder configuration, string redisHost)
		{
			configuration.Add(new RedisConfigurationSource(redisHost));
			return configuration;
		}
	}
}