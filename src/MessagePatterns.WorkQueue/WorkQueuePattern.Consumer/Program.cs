// See https://aka.ms/new-console-template for more information
using MassTransit;
using MessagePatterns.Shared.Consumers;
using MessagePatterns.Shared.Helpers;
using MessagePatterns.Shared.Messages.Abstract;

Console.WriteLine("WorkQueue Consumer!");

var rabbitMQSettings = RabbitMqConfigurationHelper.RabbitMqConnectionConfigs;
var bus = Bus.Factory.CreateUsingRabbitMq((factory) =>
{
    factory.Host(RabbitMqConfigurationHelper.RabbitMqUri, h =>
    {
        h.Username(rabbitMQSettings.UserName);
        h.Password(rabbitMQSettings.Password);
    });

    var partitionCount = 2;
    var partitioner = factory.CreatePartitioner(partitionCount);

    factory.ReceiveEndpoint("work-queue", endPoint =>
    {
        endPoint.PrefetchCount = 1;
        endPoint.Consumer<ExampleMessageConsumer>(cfg =>
        {
            //cfg.Message<IMessage>(m => m.UsePartitioner(partitioner, x => x.MessageId!.Value.ToString()));

            cfg.UseConcurrentMessageLimit(1);
        });
    });

});

await bus.StartAsync();

Console.Read();