using Domain.Common.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEvents(this IMediator mediator, DbContext context)
        {
            var entities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents.Any())
                .Select(x => x.Entity);

            var domainEvents = entities.SelectMany(x => x.DomainEvents).ToList();

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
