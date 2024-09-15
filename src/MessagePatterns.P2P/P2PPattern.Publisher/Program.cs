// See https://aka.ms/new-console-template for more information
using MessagePatterns.Shared.Helpers;
using MessagePatterns.Shared.Messages.Abstract;
using MessagePatterns.Shared.Messages.Concrete;

Console.WriteLine("P2P Publisher");

//Point to Point tasarım kalıbı, adresi verilen exchange ya da queue ya direkt olarak mesajın iletilmesidir.

var bus = BusHelper.GetBus();

var sendEndpoint = BusHelper.GetSendEndpoint(bus, "p2p");


for (int i = 1; i < 100; i++)
{
    await sendEndpoint.Send<IMessage>(new ExampleMessage() { Text = $"mesaj - {i}" });
    await Task.Delay(1000);
}
