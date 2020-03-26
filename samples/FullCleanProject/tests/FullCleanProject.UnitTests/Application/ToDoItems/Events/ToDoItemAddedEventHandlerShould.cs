using FullCleanProject.Application.ToDoItems.Events;
using FluentAssertions;
using Xunit;

namespace FullCleanProject.UnitTests.Application.ToDoItems.Events
{
    public class ToDoItemAddedEventHandlerShould
    {
        [Fact]
        public void Construct() =>
            new ToDoItemAddedEventHandler()
                .Should().BeOfType<ToDoItemAddedEventHandler>();
    }
}
