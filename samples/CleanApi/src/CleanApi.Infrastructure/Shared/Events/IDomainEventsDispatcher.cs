using CleanApi.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanApi.Infrastructure.Shared
{
    public interface IDomainEventsDispatcher
    {
        Task<List<IDomainEventNotification<IDomainEvent>>> DispatchEventsAsync(AppDbContext context);
    }
}
