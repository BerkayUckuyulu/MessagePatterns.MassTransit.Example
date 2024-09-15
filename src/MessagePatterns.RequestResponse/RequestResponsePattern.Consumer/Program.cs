// See https://aka.ms/new-console-template for more information
using MessagePatterns.Shared.Consumers;
using MessagePatterns.Shared.Helpers;

Console.WriteLine("Hello, World!");


var bus = BusHelper.GetBus<RequestResponseConsumer>("request-response");

await bus.StartAsync();

Console.Read();
