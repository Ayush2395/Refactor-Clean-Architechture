using Domain.Common.Base;
using Domain.ValueObject;

namespace Domain.Entities
{
    public class TodoList : BaseEntity
    {
        public string UserId { get; set; }
        public string? Title { get; set; }
        public Colour Colour { get; set; } = Colour.White;
        public UserProfile User { get; set; } = null!;
        public ICollection<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}
