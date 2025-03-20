using Focu.Core.Common;

namespace Focu.Core.CategoryDomain.Requests;

public class GetCategoryByIdRequest : Request
{
    public Guid Id { get; set; }
}