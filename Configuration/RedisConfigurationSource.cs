using Microsoft.Extensions.Configuration;

namespace aspnetcore_custom_config_sample.Configuration
{
	public class RedisConfigurationSource : IConfigurationSource
	{
		private readonly string _redisHost;

		public RedisConfigurationSource(string redisHost)
		{
			_redisHost = redisHost;
		}

		public IConfigurationProvider Build(IConfigurationBuilder builder)
		{
			return new RedisConfigurationProvider(_redisHost);
		}
	}
}