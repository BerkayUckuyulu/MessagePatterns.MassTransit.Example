using MessagePatterns.Shared.Messages.Abstract;

namespace MessagePatterns.Shared.Messages.Concrete
{
    public class RequestResponseResponseModel : IMessage
    {
        public string Text { get; set; }
    }
}