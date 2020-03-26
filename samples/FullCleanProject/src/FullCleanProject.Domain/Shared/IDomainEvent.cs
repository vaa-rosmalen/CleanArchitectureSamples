using MediatR;
using System;

namespace FullCleanProject.Domain.Shared
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}
