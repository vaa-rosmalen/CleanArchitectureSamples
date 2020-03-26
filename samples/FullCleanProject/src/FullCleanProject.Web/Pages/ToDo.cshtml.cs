using FullCleanProject.Application.ToDoItems.Specifications;
using FullCleanProject.Application.ToDoItems.UseCases;
using FullCleanProject.Domain.ToDoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullCleanProject.Web.Pages
{
    public class ToDoModel : PageModel
    {
        private readonly IMediator _mediator;

        public ToDoModel(IMediator mediator) => _mediator = mediator;

        public IList<ToDoItem> ToDoItems { get; private set; }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            var result = await _mediator
                .Send(new ToDoItemsQuery(new AllToDoItems()))
                .ConfigureAwait(false);

            if (result != null && result.Any())
                ToDoItems = result.ToList();
        }
    }
}
