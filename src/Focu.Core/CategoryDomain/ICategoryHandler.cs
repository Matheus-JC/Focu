using Focu.Core.CategoryDomain.Requests;
using Focu.Core.Common;

namespace Focu.Core.CategoryDomain;

public interface ICategoryHandler
{
    Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request);
    Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
    Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
    Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request);
    Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
}