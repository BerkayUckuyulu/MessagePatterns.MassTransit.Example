using MassTransit;
using MessagePatterns.Shared.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace MessagePatterns.Shared.Extensions
{
    public static class MassTransitExtensions
    {
        public static void AddMassTransitExtendMethod(this IServiceCollection services)
        {
            var rabbitMQSettings = RabbitMqConfigurationHelper.RabbitMqConnectionConfigs;

            services.AddMassTransit(configurator =>
            {
                configurator.UsingRabbitMq((context, _configurator) =>
                {
                    _configurator.Host(RabbitMqConfigurationHelper.RabbitMqUri, h =>
                    {
                        h.Username(rabbitMQSettings.UserName);
                        h.Password(rabbitMQSettings.Password);
                    });
                });
            });
        }

        public static void AddMassTransitExtendMethod<T>(this IServiceCollection services) where T : class, IConsumer, new()
        {
            var rabbitMQSettings = RabbitMqConfigurationHelper.RabbitMqConnectionConfigs;

            services.AddMassTransit(configurator =>
            {
                configurator.UsingRabbitMq((context, _configurator) =>
                {
                    _configurator.Host(RabbitMqConfigurationHelper.RabbitMqUri, h =>
                    {
                        h.Username(rabbitMQSettings.UserName);
                        h.Password(rabbitMQSettings.Password);
                    });
                });

                configurator.AddConsumer<T>();
            });

        }
    }
}

