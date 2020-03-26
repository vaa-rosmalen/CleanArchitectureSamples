using FullCleanProject.Domain.Shared;
using FullCleanProject.Domain.ToDoItems;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FullCleanProject.Application.ToDoItems.UseCases
{
    public class CreateToDoItemCommandHandler
         : IRequestHandler<CreateToDoItemCommand, ToDoItemDto>
    {
        private readonly IRepository<ToDoItem> _repository;

        public CreateToDoItemCommandHandler(IRepository<ToDoItem> repository) =>
            _repository = repository;

        public async Task<ToDoItemDto> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new ToDoItem
            {
                Description = request.CreateToDoItemRequest.Description,
                DueDate = request.CreateToDoItemRequest.DueDate,
                IsDone = request.CreateToDoItemRequest.IsDone
            };

            await _repository
                .InsertAsync(todoItem)
                .ConfigureAwait(false);

            return new ToDoItemDto(todoItem.Id);
        }
    }
}
