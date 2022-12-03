using CleanArchitecture.Demo.Core.ContributorAggregate;
using CleanArchitecture.Demo.SharedKernel;

namespace CleanArchitecture.Demo.Core.ProjectAggregate.Events;
public class ContributorAddedToItemEvent : DomainEventBase
{
  public int ContributorId { get; set; }
  public ToDoItem Item { get; set; }

  public ContributorAddedToItemEvent(ToDoItem item, int contributorId)
  {
    Item = item;
    ContributorId = contributorId;
  }
}
