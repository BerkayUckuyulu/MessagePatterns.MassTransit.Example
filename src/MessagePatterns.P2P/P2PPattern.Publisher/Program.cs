// See https://aka.ms/new-console-template for more information
using MessagePatterns.Shared.Helpers;
using MessagePatterns.Shared.Messages.Abstract;
using MessagePatterns.Shared.Messages.Concrete;

Console.WriteLine("P2P Publisher");

var bus = BusHelper.GetBus();

var sendEndpoint = BusHelper.GetSendEndpoint(bus, "trial");


for (int i = 1; i < 100; i++)
{
    await sendEndpoint.Send<IMessage>(new ExampleMessage() { Text = $"mesaj - {i}" });
    await Task.Delay(1000);
}
