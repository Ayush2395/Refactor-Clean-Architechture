using Domain.Common.Base;
using Domain.Entities;

namespace Domain.Events
{
    public record TodoItemsDeleteEvent(TodoItem TodoItem) : DomainEvents;
}
