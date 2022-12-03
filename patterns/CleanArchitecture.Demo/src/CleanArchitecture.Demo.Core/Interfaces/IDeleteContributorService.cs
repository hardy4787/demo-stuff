using Ardalis.Result;

namespace CleanArchitecture.Demo.Core.Interfaces;
public interface IDeleteContributorService
{
  public Task<Result> DeleteContributor(int contributorId);
}
