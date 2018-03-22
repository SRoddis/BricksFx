using BricksFx.DI;

namespace BricksFx.Ninject
{
    public interface INinjectNamedDependency : IDependency
    {
        string Name { get; }
    }
}