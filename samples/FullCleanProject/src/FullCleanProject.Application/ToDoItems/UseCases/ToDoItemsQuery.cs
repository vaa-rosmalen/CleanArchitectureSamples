using Ardalis.GuardClauses;
using FullCleanProject.Domain.Shared;
using FullCleanProject.Domain.ToDoItems;
using MediatR;
using System.Collections.Generic;
using LinqBuilder;

namespace FullCleanProject.Application.ToDoItems.UseCases
{
    public class ToDoItemsQuery
        : IRequest<IEnumerable<ToDoItem>>
    {
        public readonly QuerySpecification<ToDoItem> Specification;

        public ToDoItemsQuery(QuerySpecification<ToDoItem> specification)
        {
            Guard.Against.Null(specification, "Specification");

            Specification = specification;
        }
    }
}
