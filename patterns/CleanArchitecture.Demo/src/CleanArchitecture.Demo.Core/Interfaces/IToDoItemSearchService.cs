using Ardalis.Result;
using CleanArchitecture.Demo.Core.ProjectAggregate;

namespace CleanArchitecture.Demo.Core.Interfaces;
public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
