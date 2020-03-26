using FullCleanProject.Application.ToDoItems.Specifications;
using FluentAssertions;
using Xunit;

namespace FullCleanProject.UnitTests.Application.ToDoItems.Specifications
{
    public class AllToDoItemsShould
    {
        [Fact]
        public void Construct() =>
            new AllToDoItems()
                .Should().BeOfType<AllToDoItems>();
    }
}
