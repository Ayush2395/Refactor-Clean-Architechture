using Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Common.Extensions
{
    public static class IdentityServiceExtension
    {
        public static Result<string> ToApplication(this IdentityResult result, string? message = default)
            => result.Succeeded
            ? Result<string>.Success(message)
            : Result<string>.Failure(result.Errors.Select(x => x.Description));
    }
}
