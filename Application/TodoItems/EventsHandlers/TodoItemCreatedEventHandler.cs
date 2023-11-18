using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.TodoItems.EventsHandlers
{
    public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemsCreatedEvent>
    {
        private readonly ILogger<TodoItemCreatedEventHandler> _logger;

        public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TodoItemsCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Learn domain event : {DomainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
