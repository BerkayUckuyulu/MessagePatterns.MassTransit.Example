using MassTransit;

namespace MessagePatterns.Shared.Helpers
{
    public static class BusHelper
    {
        public static IBusControl GetBus()
        {
            var rabbitMQSettings = RabbitMqConfigurationHelper.RabbitMqConnectionConfigs;
            return Bus.Factory.CreateUsingRabbitMq((factory) =>
            {
                factory.Host(RabbitMqConfigurationHelper.RabbitMqUri, h =>
                {
                    h.Username(rabbitMQSettings.UserName);
                    h.Password(rabbitMQSettings.Password);
                });

            });
        }

        public static IBusControl GetBus<T>(string queueName) where T : class, IConsumer, new()
        {
            var rabbitMQSettings = RabbitMqConfigurationHelper.RabbitMqConnectionConfigs;
            return Bus.Factory.CreateUsingRabbitMq((factory) =>
            {
                factory.Host(RabbitMqConfigurationHelper.RabbitMqUri, h =>
                {
                    h.Username(rabbitMQSettings.UserName);
                    h.Password(rabbitMQSettings.Password);
                });

                factory.ReceiveEndpoint(queueName, endPoint =>
                {

                    // Bu şekilde massTransit tarafından default olarak fanout tipinde oluşturulan exchange türü değiştirilebilir.
                    //endPoint.Bind<T>(x =>
                    //{
                    //    x.ExchangeType = RabbitMQ.Client.ExchangeType.Direct;
                    //});
                    endPoint.Consumer<T>();
                });

            });
        }

        public static ISendEndpoint GetSendEndpoint(IBusControl bus, string queueName) => bus.GetSendEndpoint(new($"{RabbitMqConfigurationHelper.RabbitMqUri}/{queueName}")).Result;
    }
}

