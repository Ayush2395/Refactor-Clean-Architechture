using Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common.Base
{
    public abstract class BaseEntity : BaseAuditableEntity, IDomainEvents
    {
        public string Id { get; set; }
        private readonly List<DomainEvents> _domainEvents = new();
        [NotMapped]
        public IReadOnlyCollection<DomainEvents> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvents(DomainEvents domainEvents)
        {
            _domainEvents.Add(domainEvents);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void RemoveDomainEvents(DomainEvents domainEvents)
        {
            _domainEvents.Remove(domainEvents);
        }
    }
}
