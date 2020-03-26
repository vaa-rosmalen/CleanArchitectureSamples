using MediatR;
using System;

namespace CleanApi.Domain.Shared
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}
