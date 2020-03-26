using FullCleanProject.Application.ToDoItems.Specifications;
using FluentAssertions;
using Xunit;

namespace FullCleanProject.UnitTests.Application.ToDoItems.Specifications
{
    public class ToDoItemsByStatusShould
    {
        [Fact]
        public void Construct() =>
            new ToDoItemsByStatus(true)
                .Should().BeOfType<ToDoItemsByStatus>();
    }
}
