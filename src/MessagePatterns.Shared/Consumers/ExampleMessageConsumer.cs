using MassTransit;
using MessagePatterns.Shared.Messages.Abstract;

namespace MessagePatterns.Shared.Consumers
{
    public class ExampleMessageConsumer : IConsumer<IMessage>
    {
        public Task Consume(ConsumeContext<IMessage> context)
        {
            Console.WriteLine(context.Message.Text);

            return Task.CompletedTask;
        }
    }
}