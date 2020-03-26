using FullCleanProject.FakeData.ToDoItems;
using FullCleanProject.Infrastructure.Shared;
using System.Linq;
namespace FullCleanProject.IntegrationTests.Helpers
{
    public static class DataInitializer
    {

        public static void SeedToDoItemsTestData(this AppDbContext db)
        {
            if (!db.ToDoItems.Any())
            {
                db.AddRange(ToDoItemData.ToDoItemsForTesting);
                db.SaveChanges();
            }
        }

    }
}