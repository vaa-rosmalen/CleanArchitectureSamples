using System;
using System.Linq.Expressions;
using FullCleanProject.Domain.ToDoItems;
using LinqBuilder;

namespace FullCleanProject.Application.ToDoItems.Specifications
{
    public class AllToDoItems : QuerySpecification<ToDoItem>
    {
        public override Expression<Func<ToDoItem, bool>> AsExpression() =>
            item => true;
    }
}
