using Focu.Core.Common;

namespace Focu.Core.Requests.Category;

public class GetCategoryByIdRequest : Request
{
    public Guid Id { get; set; }
}