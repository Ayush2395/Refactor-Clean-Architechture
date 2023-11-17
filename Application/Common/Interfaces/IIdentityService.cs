using Application.Common.Models;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUsernameAsync(string userId);
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<(Result<string>, string)> CreateUserAsync(string username, string password);
        Task<(Result<string>, string)> DeleteAsync(string userId);
        Task<(Result<string>, string)> UpdateAsync(string userId);
    }
}
