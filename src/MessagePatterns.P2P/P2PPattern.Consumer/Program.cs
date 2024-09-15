// See https://aka.ms/new-console-template for more information
using MessagePatterns.Shared.Consumers;
using MessagePatterns.Shared.Helpers;

Console.WriteLine("P2P Consumer");

var bus = BusHelper.GetBus<ExampleMessageConsumer>("trial");

await bus.StartAsync();

Console.Read();

