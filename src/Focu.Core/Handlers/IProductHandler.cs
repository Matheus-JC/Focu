using Focu.Core.Models;
using Focu.Core.Requests.Orders;
using Focu.Core.Responses;

namespace Focu.Core.Handlers;

public interface IProductHandler
{
    Task<PagedResponse<List<Product>>> GetAllAsync(GetAllProductsRequest request);
    Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request);
}