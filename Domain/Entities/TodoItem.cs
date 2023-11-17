using Domain.Common.Base;
using Domain.Enums;
using Domain.Events;

namespace Domain.Entities
{
    public class TodoItem : BaseEntity
    {
        public string? ListId { get; set; }
        public string? Title { get; set; }
        public string? Notes { get; set; }
        public Priority Priority { get; set; }
        private bool _done;

        public bool Done
        {
            get => _done;
            set
            {
                if (!_done || value == false)
                {
                    AddDomainEvents(new TodoItemsCompletedEvent(this));
                }
                _done = value;
            }
        }
        public TodoList List { get; set; } = null!;
    }
}
