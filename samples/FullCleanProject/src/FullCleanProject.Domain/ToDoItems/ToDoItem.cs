using FullCleanProject.Domain.Shared;
using System;

namespace FullCleanProject.Domain.ToDoItems
{
    public class ToDoItem : Entity
    {
        public ToDoItem() =>
            AddDomainEvent(new ToDoItemAddedEvent(this));

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }
    }
}
