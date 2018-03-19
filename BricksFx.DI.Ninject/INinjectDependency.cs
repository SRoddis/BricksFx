using BricksFx.DI.Dependency;

namespace BricksFx.DI.Ninject
{
    public interface INinjectDependency : IDependency
    {
        string Name { get; }
    }
}