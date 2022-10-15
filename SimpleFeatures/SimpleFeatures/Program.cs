using Autofac;
using SimpleFeatures;
using SimpleFeatures.AutoMapper;

IContainer _container;

void RegisterType()
{
    var builder = new ContainerBuilder();
    builder.RegisterType<AutoMapperExampleUse>().As<ISolution>();
    _container = builder.Build();
}

RegisterType();

using (var scope = _container.BeginLifetimeScope())
{
    var currentSolution = scope.Resolve<ISolution>();
    currentSolution.Execute();
}

Console.ReadLine();