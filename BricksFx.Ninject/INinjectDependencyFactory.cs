using BricksFx.DI;

namespace BricksFx.Ninject
{
    public interface INinjectDependencyFactory : IInterfaceDependency
    {
        bool IsFactory { get; }
    }
}