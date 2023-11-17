using Domain.Common.Interfaces;

namespace Domain.Common.Base
{
    public class BaseAuditableEntity : IAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
