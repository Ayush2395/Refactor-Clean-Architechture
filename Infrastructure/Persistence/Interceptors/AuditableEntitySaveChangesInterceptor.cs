using Application.Common.Interfaces;
using Domain.Common.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Persistence.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public AuditableEntitySaveChangesInterceptor(ICurrentUserService currentUserService, IDateTime dateTime)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            UpdateEntity(eventData.Context);
            return base.SavedChanges(eventData, result);
        }
        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            UpdateEntity(eventData.Context);
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }
        public void UpdateEntity(DbContext? contex)
        {
            if (contex is null) return;
            foreach (var entry in contex.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = _dateTime.Now;
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                }
                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                {
                    entry.Entity.LastModifiedAt = _dateTime.Now;
                    entry.Entity.LastModifiedBy = _currentUserService.UserId;
                }
            }
        }
    }
    public static class Extension
    {
        public static bool HasOwnedChangeEntity(this EntityEntry entity)
            => entity.References.All(x => x.TargetEntry != null
            && (x.TargetEntry.State == EntityState.Added || x.TargetEntry.State == EntityState.Modified)
            && x.TargetEntry.Metadata.IsOwned());
    }
}
