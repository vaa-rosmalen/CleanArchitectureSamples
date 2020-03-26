using MediatR;

namespace FullCleanProject.Domain.Shared
{
    public interface IDomainEventNotification<out TEventType>
        : INotification
    {
        TEventType DomainEvent { get; }
    }
}
