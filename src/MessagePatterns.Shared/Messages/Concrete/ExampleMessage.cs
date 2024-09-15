using MessagePatterns.Shared.Messages.Abstract;

namespace MessagePatterns.Shared.Messages.Concrete
{
    public class ExampleMessage : IMessage
    {
        public string Text { get; set; }
    }
}