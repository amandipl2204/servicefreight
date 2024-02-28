using Utilities.MessageStatus;

namespace Utilities.Contract
{
    public interface IResponseWrappers
    {
        bool HasMessages { get; }
        bool HasErrors { get; }
        List<MessageStatusDetailModel> Messages { get; }
        MessageStatusModel ToMessageStatus(string description, string responseCode);
        object? ToResponse(string description, string responseCode);
    }
}
