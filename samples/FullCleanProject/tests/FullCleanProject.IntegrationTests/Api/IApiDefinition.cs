using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using FullCleanProject.Domain.ToDoItems;

namespace FullCleanProject.IntegrationTests.Api
{
    public interface IApiDefinition
    {
        [Get("/api/todo")]
        Task<List<ToDoItem>> GetAllToDoItems();
    }
}
