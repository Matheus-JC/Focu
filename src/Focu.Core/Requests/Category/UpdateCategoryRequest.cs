using System.ComponentModel.DataAnnotations;
using Focu.Core.Common;

namespace Focu.Core.Requests.Category;

public class UpdateCategoryRequest : Request
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Invalid Title")]
    [MaxLength(80, ErrorMessage = "title must contain up to 80 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Invalid Description")]
    public string Description { get; set; } = string.Empty;
}