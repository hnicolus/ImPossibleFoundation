using System;
using System.Threading.Tasks;

namespace ImPossibleFoundation.DomainEvents
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}