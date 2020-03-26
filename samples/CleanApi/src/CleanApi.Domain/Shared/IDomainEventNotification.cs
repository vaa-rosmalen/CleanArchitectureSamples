using MediatR;

namespace CleanApi.Domain.Shared
{
    public interface IDomainEventNotification<out TEventType>
        : INotification
    {
        TEventType DomainEvent { get; }
    }
}
