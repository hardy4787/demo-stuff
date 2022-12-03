using Ardalis.Specification;

namespace CleanArchitecture.Demo.Core.ProjectAggregate.Specifications;
public class IncompleteItemsSpec : Specification<ToDoItem>
{
  public IncompleteItemsSpec()
  {
    Query.Where(item => !item.IsDone);
  }
}
