// See https://aka.ms/new-console-template for more information
using MessagePatterns.Shared.Helpers;
using MessagePatterns.Shared.Messages.Abstract;
using MessagePatterns.Shared.Messages.Concrete;

Console.WriteLine("Hello, World!");

var bus = BusHelper.GetBus();

var receiveEndponint = BusHelper.GetSendEndpoint(bus, "work-queue");

int i = 0;

while (i < 100)
{
    await receiveEndponint.Send<IMessage>(new ExampleMessage() { Text = $"message - {++i}" });
}

Console.Read();