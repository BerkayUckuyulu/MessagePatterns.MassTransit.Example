// See https://aka.ms/new-console-template for more information
using MessagePatterns.Shared.Consumers;
using MessagePatterns.Shared.Helpers;

Console.WriteLine("Publish-Subscribe Consumer");


var bus = BusHelper.GetBus<ExampleMessageConsumer>("publish-subscribe");

await bus.StartAsync();

Console.Read();

