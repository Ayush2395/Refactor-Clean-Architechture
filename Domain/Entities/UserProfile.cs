using Domain.Common.Base;

namespace Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public ICollection<TodoList> Lists { get; set; }
    }
}
