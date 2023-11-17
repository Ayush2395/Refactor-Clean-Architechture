using Domain.Common.Base;
using Domain.Entities;

namespace Domain.Events
{
    public record TodoItemsCreatedEvent(TodoItem Items) : DomainEvents;
}
