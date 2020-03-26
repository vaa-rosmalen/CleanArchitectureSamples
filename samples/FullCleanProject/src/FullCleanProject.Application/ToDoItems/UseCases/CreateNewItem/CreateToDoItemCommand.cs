using MediatR;

namespace FullCleanProject.Application.ToDoItems.UseCases
{
    public class CreateToDoItemCommand
        : IRequest<ToDoItemDto>
    {
        public CreateToDoItemCommand(CreateToDoItemRequest createToDoItemRequest) =>
            CreateToDoItemRequest = createToDoItemRequest;

        public CreateToDoItemRequest CreateToDoItemRequest { get; }
    }
}
