using Domain.Common.Base;
using Domain.Entities;

namespace Domain.Events
{
    public record TodoItemsCompletedEvent(TodoItem item) : DomainEvents;
}
