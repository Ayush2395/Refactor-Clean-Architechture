using Domain.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppUser : IdentityUser
    {
        public UserProfile UserProfile { get; set; } = null!;
    }
}
