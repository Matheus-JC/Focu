namespace Focu.Core.Common;

public abstract class PagedRequest : Request
{
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
}