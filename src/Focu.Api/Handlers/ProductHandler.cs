using Focu.Api.Data;
using Focu.Core.Handlers;
using Focu.Core.Models;
using Focu.Core.Requests.Orders;
using Focu.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Focu.Api.Handlers;

public class ProductHandler(AppDbContext context) : IProductHandler
{
    public async Task<PagedResponse<List<Product>>> GetAllAsync(GetAllProductsRequest request)
    {
        var query = context
            .Products
            .AsNoTracking()
            .Where(x => x.IsActive == true)
            .OrderBy(x => x.Title);

        var products = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new PagedResponse<List<Product>>(
            products,
            count,
            request.PageNumber,
            request.PageSize);
    }

    public async Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request)
    {
        var product = await context
            .Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Slug == request.Slug && x.IsActive == true);

        return product is null
            ? new Response<Product?>(null, StatusCodes.Status404NotFound, "Product not found")
            : new Response<Product?>(product);
    }
}

