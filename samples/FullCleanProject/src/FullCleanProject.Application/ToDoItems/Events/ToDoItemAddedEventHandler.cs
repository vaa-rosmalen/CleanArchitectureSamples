using FullCleanProject.Domain.ToDoItems;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FullCleanProject.Application.ToDoItems.Events
{
    public class ToDoItemAddedEventHandler
        : INotificationHandler<ToDoItemAddedEvent>
    {
        public async Task Handle(ToDoItemAddedEvent notification, CancellationToken cancellationToken)
        {
            await Task.Delay(500);
        }
    }
}
