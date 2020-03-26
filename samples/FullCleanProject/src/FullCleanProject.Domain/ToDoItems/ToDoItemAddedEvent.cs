using FullCleanProject.Domain.Shared;

namespace FullCleanProject.Domain.ToDoItems
{
    public class ToDoItemAddedEvent
        : DomainEventBase
    {
        public ToDoItemAddedEvent(ToDoItem todoItem) =>
            ToDoItem = todoItem;

        public ToDoItem ToDoItem { get; }
    }
}
