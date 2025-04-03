using Focu.Core.Common;

namespace Focu.Core.Requests.Category;

public class DeleteCategoryRequest : Request
{
    public Guid Id { get; set; }
}