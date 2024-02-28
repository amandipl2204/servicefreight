using Utilities.Enums;

namespace Utilities.MessageStatus
{
    public class MessageStatusDetailModel
    {
        public string? Code { get; set; }

        public Category? Category { get; set; }

        public string? Description { get; set; }

        public string? Element { get; set; }

        public string? ElementValue { get; set; }

        public string? Location { get; set; }
    }
}
