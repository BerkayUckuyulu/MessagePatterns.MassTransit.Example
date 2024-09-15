using MessagePatterns.Shared.Models;
using Microsoft.Extensions.Configuration;

namespace MessagePatterns.Shared.Helpers
{
    public static class RabbitMqConfigurationHelper
    {
        public static RabbitMQSettings RabbitMqConnectionConfigs = GetRabbitMqConnectionSettings();

        public static Uri RabbitMqUri = (new Uri($"rabbitmq://{RabbitMqConnectionConfigs!.Host}:{RabbitMqConnectionConfigs.Port}"));

        private static RabbitMQSettings GetRabbitMqConnectionSettings()
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../../MessagePatterns.Shared/");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(basePath))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            return configuration.GetSection("RabbitMQ").Get<RabbitMQSettings>()!;
        }
    }
}