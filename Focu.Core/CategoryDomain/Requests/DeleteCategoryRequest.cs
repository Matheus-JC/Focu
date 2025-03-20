using Focu.Core.Common;

namespace Focu.Core.CategoryDomain.Requests;

public class DeleteCategoryRequest : Request
{
    public Guid Id { get; set; }
}