namespace Utilities.MessageStatus
{
    public class MessageStatusModel
    {
        public string? ResponseCode { get; set; }
        public string? Description { get; set; }
        public string? MessageSource { get; set; }
        public List<MessageStatusDetailModel> Details { get; set; } = new List<MessageStatusDetailModel>();
    }
}
