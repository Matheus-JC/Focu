using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Models;
using Focu.Core.Requests.Category;
using Focu.Core.Responses;
using Focu.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Focu.Api.Handlers;

public class CategoryHandler(AppDbContext dbContext) : ICategoryHandler
{
    public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
    {
        var query = dbContext.Categories
            .AsNoTracking()
            .Where(x => x.UserId == request.UserId)
            .OrderBy(x => x.Title);
        
        var categories = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        
        var count = await query.CountAsync();
        
        return new PagedResponse<List<Category>>(categories, count, request.PageNumber, request.PageSize);
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        var category = await dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
        
        return category is null
            ? new Response<Category?>(null, StatusCodes.Status404NotFound, "Category not found")
            : new Response<Category?>(category);
    }

    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        var category = new Category
        {
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description
        };
        
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
        
        return new Response<Category?>(category, StatusCodes.Status201Created, "Category created");
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        var category = await dbContext.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
        
        if(category is null)
            return new Response<Category?>(null, StatusCodes.Status404NotFound, "Category not found");
        
        category.Title = request.Title;
        category.Description = request.Description;
        await dbContext.SaveChangesAsync();
        
        return new Response<Category?>(category, message: "Category updated");
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        var category = await dbContext.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
        
        if(category is null)
            return new Response<Category?>(null, StatusCodes.Status404NotFound, "Category not found");
        
        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync();
        
        return new Response<Category?>(category, message: "Category deleted");
    }
}