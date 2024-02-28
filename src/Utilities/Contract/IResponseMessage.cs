using Utilities.MessageStatus;

namespace Utilities.Contract
{
    public interface IResponseMessage
    {
        MessageStatusModel? MessageStatus { get; set; }
    }
}
