using Domain.Common.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common.Interfaces
{
    public interface IDomainEvents
    {
        public IReadOnlyCollection<DomainEvents> DomainEvents { get; }
        public void AddDomainEvents(DomainEvents domainEvents);
        public void RemoveDomainEvents(DomainEvents domainEvents);
        public void ClearDomainEvents();
    }
}
