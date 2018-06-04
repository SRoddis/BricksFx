using BricksFx.DI;

namespace BricksFx.Ninject
{
    public interface INinjectFactoryDependency : IInterfaceDependency
    {
        bool IsFactory { get; }
    }
}