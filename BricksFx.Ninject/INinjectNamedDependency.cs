using BricksFx.DI;

namespace BricksFx.Ninject
{
    public interface INinjectNamedDependency : IInterfaceDependency
    {
        string Name { get; }
    }
}