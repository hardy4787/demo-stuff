using Ardalis.Specification;

namespace CleanArchitecture.Demo.SharedKernel.Interfaces;
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
