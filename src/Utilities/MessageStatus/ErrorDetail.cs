using Utilities.Enums;

namespace Utilities.MessageStatus
{
    public class ErrorDetail
    {
        public string Code { get; }
        public Category Category { get; }
        public string Description { get; }
        public string Element { get; }

        public ErrorDetail(string code, Category category, string description, string element)
        {
            Code = code;
            Category = category;
            Description = description;
            Element = element;
        }

        public MessageStatusDetailModel ToDetailModel(string? elementValue, string? location)
        {
            return new MessageStatusDetailModel()
            {
                Code = Code,
                Category = Category, 
                Description = Description,
                Element = Element,
                ElementValue = elementValue,
                Location = location
            };
        }
    }
}
