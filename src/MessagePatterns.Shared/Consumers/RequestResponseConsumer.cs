using MassTransit;
using MessagePatterns.Shared.Messages.Concrete;

namespace MessagePatterns.Shared.Consumers
{
    public class RequestResponseConsumer : IConsumer<RequestResponseRequestModel>
    {
        public async Task Consume(ConsumeContext<RequestResponseRequestModel> context)
        {
            Console.WriteLine(context.Message.Text);
            await context.RespondAsync<RequestResponseResponseModel>(new() { Text = $"{context.Message.MessageNo}" });
        }
    }
}

