using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence
{
    public class AppDbContextInitializer : IAppDbContextInitializer
    {
        private readonly ILogger<AppDbContextInitializer> _logger;
        private readonly IDateTime _dateTime;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppDbContextInitializer(ILogger<AppDbContextInitializer> logger, AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IDateTime dateTime)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _dateTime = dateTime;
        }

        public async Task InitializeAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
        private async Task TrySeedAsync()
        {
            try
            {
                // Default roles
                var administratorRole = new IdentityRole("Admin");

                if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
                {
                    await _roleManager.CreateAsync(administratorRole);
                }

                // Default users
                var administrator = new AppUser { UserName = "admin@admin.com", Email = "admin@admin.com" };

                if (_userManager.Users.All(u => u.UserName != administrator.UserName))
                {
                    await _userManager.CreateAsync(administrator, "Test@123");
                    if (!string.IsNullOrWhiteSpace(administratorRole.Name))
                    {
                        await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
                    }
                    await _context.UserProfiles.AddAsync(new UserProfile
                    {
                        Id = administrator.Id,
                        CreatedAt = _dateTime.Now,
                        CreatedBy = administrator.Id,
                        FirstName = "Ayush",
                    });
                }

                // Default data
                // Seed, if necessary
                if (!_context.TodoLists.Any())
                {
                    _context.TodoLists.Add(new TodoList
                    {
                        UserId = administrator.Id,
                        Title = "Todo List",
                        Items =
                        {
                            new TodoItem { Title = "Make a todo list 📃" },
                            new TodoItem { Title = "Check off the first item ✅" },
                            new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                            new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                        }
                    });

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
