using System.Net;
using System.Net.Http.Json;
using Focu.Core.Handlers;
using Focu.Core.Models;
using Focu.Core.Requests.Category;
using Focu.Core.Responses;

namespace Focu.Web.Handlers;

public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
    
    public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request) => 
        await _client.GetFromJsonAsync<PagedResponse<List<Category>>>("v1/categories") 
            ?? new PagedResponse<List<Category>>(null, (int)HttpStatusCode.BadRequest, "Could not find the categories");

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request) =>
        await _client.GetFromJsonAsync<Response<Category?>>($"v1/categories/{request.Id}")
            ?? new Response<Category?>(null, (int)HttpStatusCode.BadRequest, "Could not find the category");

    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/categories", request);
        
        return await result.Content.ReadFromJsonAsync<Response<Category?>>() 
               ?? new Response<Category?>(null, (int)result.StatusCode, "Error creating category");
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/categories/{request.Id}", request);
        
        return await result.Content.ReadFromJsonAsync<Response<Category?>>() 
            ?? new Response<Category?>(null, (int)result.StatusCode, "Error updating category");
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        var result = await _client.DeleteAsync($"v1/categories/{request.Id}");
        
        return await result.Content.ReadFromJsonAsync<Response<Category?>>() 
            ?? new Response<Category?>(null, (int)result.StatusCode, "Error deleting category");
    }
}