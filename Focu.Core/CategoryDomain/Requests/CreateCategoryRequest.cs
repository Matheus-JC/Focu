using System.ComponentModel.DataAnnotations;
using Focu.Core.Common;

namespace Focu.Core.CategoryDomain.Requests;

public class CreateCategoryRequest : Request
{
    [Required(ErrorMessage = "Invalid Title")]
    [MaxLength(80, ErrorMessage = "title must contain up to 80 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Invalid Description")]
    public string Description { get; set; } = string.Empty;
}