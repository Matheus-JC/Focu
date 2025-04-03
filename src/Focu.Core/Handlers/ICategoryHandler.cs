using Focu.Core.Common;
using Focu.Core.Models;
using Focu.Core.Requests.Category;
using Focu.Core.Responses;

namespace Focu.Core.Handlers;

public interface ICategoryHandler
{
    Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request);
    Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
    Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
    Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request);
    Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
}