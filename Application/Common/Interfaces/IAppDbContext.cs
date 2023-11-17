using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<TodoItem> TodoItems { get; }
        public DbSet<TodoList> TodoLists { get; }
        public DbSet<UserProfile> UserProfiles { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
