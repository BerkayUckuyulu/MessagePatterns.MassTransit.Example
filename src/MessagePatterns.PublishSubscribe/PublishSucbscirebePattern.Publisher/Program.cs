// See https://aka.ms/new-console-template for more information
using MessagePatterns.Shared.Helpers;
using MessagePatterns.Shared.Messages.Abstract;
using MessagePatterns.Shared.Messages.Concrete;

Console.WriteLine("Publish-Subscribe Publisher");

var bus = BusHelper.GetBus();


await bus.StartAsync();

int i = 0;
while (i < 100)
{
    await bus.Publish<IMessage>(new ExampleMessage() { Text = $"message - {i++}" });
    await Task.Delay(1000);

}