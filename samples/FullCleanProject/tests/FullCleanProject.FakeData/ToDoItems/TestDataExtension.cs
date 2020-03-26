using FullCleanProject.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore.Internal;

namespace FullCleanProject.FakeData.ToDoItems
{
    public static class TestDataExtension
    {
        public static void Seed(this AppDbContext dbContext)
        {
            if (!dbContext.ToDoItems.Any())
            {
                dbContext.ToDoItems.AddRange(ToDoItemData.GenerateTestData(100));
                dbContext.SaveChanges();
            }
        }
    }
}