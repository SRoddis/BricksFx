using BricksFx.DI.Dependency;

namespace BricksFx.DI.Ninject
{
    public interface INinjectNamedDependency : IDependency
    {
        string Name { get; }
    }
}