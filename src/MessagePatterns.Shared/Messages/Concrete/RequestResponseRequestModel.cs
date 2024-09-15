using MessagePatterns.Shared.Messages.Abstract;

namespace MessagePatterns.Shared.Messages.Concrete
{
    public class RequestResponseRequestModel : IMessage
    {
        public int MessageNo { get; set; }
        public string Text { get; set; }
    }
}