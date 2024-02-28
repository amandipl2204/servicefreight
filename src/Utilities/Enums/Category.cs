using System.Text.Json.Serialization;

namespace Utilities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter<Category>))]
    public enum Category
    {
        Error,
        Fault,
        Warning,
        Overridden
    }
}
