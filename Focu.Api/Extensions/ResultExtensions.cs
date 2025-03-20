using Focu.Core.Common;

namespace Focu.Api.Extensions;

public static class ResultExtensions
{
    public static IResult ToProblem<T>(this Response<T> response) => 
        Results.Problem(
            title: response.Message ?? "An error occurred",
            statusCode: response.Code
        );
    
    public static IResult ToValidationProblem<T>(this Response<T> response) => 
        Results.ValidationProblem(
            title: response.Message ?? "An error occurred",
            statusCode: response.Code,
            errors: response.ValidationErrors
        );
}