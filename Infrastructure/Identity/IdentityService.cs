using Application.Common.Interfaces;
using Application.Common.Models;
using Infrastructure.Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserClaimsPrincipalFactory<AppUser> _userClaimsPrincipalFactory;

        public IdentityService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IAuthorizationService authorizationService, IUserClaimsPrincipalFactory<AppUser> userClaimsPrincipalFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authorizationService = authorizationService;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        }

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return false;
            var principle = await _userClaimsPrincipalFactory.CreateAsync(user);
            var result = await _authorizationService.AuthorizeAsync(principle, policyName);
            return result.Succeeded;
        }

        public async Task<(Result<string>, string)> CreateUserAsync(string username, string password)
        {
            var result = new IdentityResult();
            var appuser = new AppUser
            {
                UserName = username,
                Email = username
            };
            var role = new IdentityRole("User");
            if (_roleManager.Roles.All(x => x.Name != role.Name))
            {
                await _roleManager.CreateAsync(role);
            }
            if (_userManager.Users.All(x => x.UserName != username))
            {
                result = await _userManager.CreateAsync(appuser, password);
                if (result.Succeeded && !string.IsNullOrWhiteSpace(role.Name))
                {
                    await _userManager.AddToRoleAsync(appuser, role.Name);
                }
                return (result.ToApplication(), appuser.Id);
            }
            return (result.ToApplication(), string.Empty);
        }

        public async Task<(Result<string>, string)> DeleteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user!);
            return (result.ToApplication(), string.Empty);
        }

        public async Task<string> GetUsernameAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return string.Empty;
            return user.UserName!;
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return false;
            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<(Result<string>, string)> UpdateAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.UpdateAsync(user!);
            return (result.ToApplication(), string.Empty);
        }
    }
}
