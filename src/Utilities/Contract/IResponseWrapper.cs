namespace Utilities.Contract
{
    public interface IResponseWrapper<out TResponse> : IResponseWrappers where TResponse : IResponseMessage
    {
        TResponse? Response {  get; }
    }
}
