using Utilities.Enums;
using Utilities.MessageStatus;

namespace Utilities.Constants
{
    public static class Messages
    {
        private static readonly Dictionary<string, ErrorDetail> ValidationErrors = CreateDictionary();

        public static ErrorDetail EntityNotFound => new ErrorDetail(Codes.EntityNotFound, Category.Error, Descriptions.EntityNotFound, "plant");

        public static ErrorDetail GetErrorDetail(string code, string description, string element, Category category = Category.Error)
        {
            return new ErrorDetail(code, category, description, element);
        }

        private static Dictionary<string, ErrorDetail> CreateDictionary() 
        {
            var dictionary = new Dictionary<string, ErrorDetail>()
            {

            };
            return dictionary;
        }

        private readonly struct Descriptions
        {
            public const string EntityNotFound = "Requested record was not found or inaccessible";
        }
    }
}
