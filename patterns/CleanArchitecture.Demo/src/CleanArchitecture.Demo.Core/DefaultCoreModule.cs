using Autofac;
using CleanArchitecture.Demo.Core.Interfaces;
using CleanArchitecture.Demo.Core.Services;

namespace CleanArchitecture.Demo.Core;
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    builder.RegisterType<DeleteContributorService>()
        .As<IDeleteContributorService>().InstancePerLifetimeScope();
  }
}
