using Domain.Enums;

namespace Application.TodoLists.Query.GetTodoList
{
    public class TodoItemDto
    {
        public string ItemId { get; init; } = string.Empty;
        public string Title { get; init; } = string.Empty;
        public string Notes { get; init; } = string.Empty;
        public Priority Priority { get; init; }
    }
}
