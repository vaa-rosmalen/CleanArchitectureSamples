using System;
using FullCleanProject.Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FullCleanProject.Domain.ToDoItems;

namespace FullCleanProject.Infrastructure.Shared
{
    public class AppDbContext : DbContext
    {
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;
        private readonly IMediator _mediator;

        public AppDbContext(
           DbContextOptions<AppDbContext> options,
           IDomainEventsDispatcher domainEventsDispatcher,
           IMediator mediator)
           : base(options)
        {
            _domainEventsDispatcher = domainEventsDispatcher;
            _mediator = mediator;
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            SetTimestampFields();

            var notifications = await _domainEventsDispatcher.DispatchEventsAsync(this).ConfigureAwait(false);
            var saveResult = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken).ConfigureAwait(false);

            var tasks = notifications
                .Select(async (notification) =>
                {
                    await _mediator.Publish(notification, cancellationToken);
                });

            await Task.WhenAll(tasks);

            return saveResult;
        }

        public override int SaveChanges()
        {
            SetTimestampFields();
            return base.SaveChanges();
        }

        private void SetTimestampFields()
        {
            var entries = ChangeTracker.Entries();

            entries.Where(e => e.State == EntityState.Added).ToList().ForEach(entry =>
                entry.Property(nameof(Entity.CreatedAt)).CurrentValue = DateTime.Now);

            entries.Where(e => e.State == EntityState.Modified).ToList().ForEach(entry =>
                entry.Property(nameof(Entity.ModifiedAt)).CurrentValue = DateTime.Now);
        }
    }
}
