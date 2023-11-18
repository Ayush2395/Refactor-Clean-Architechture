namespace Application.TodoLists.Query.GetTodoList
{
    public class TodoListDto
    {
        public TodoListDto()
        {
            Items = Array.Empty<TodoItemDto>();
        }
        public string? Id { get; init; }
        public string? Title { get; init; }
        public string? Colour { get; init; }
        public IReadOnlyCollection<TodoItemDto> Items { get; init; }
    }
}
