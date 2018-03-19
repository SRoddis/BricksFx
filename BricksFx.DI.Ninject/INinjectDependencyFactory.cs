using BricksFx.DI.Dependency;

namespace BricksFx.DI.Ninject
{
    public interface INinjectDependencyFactory : IDependency
    {
        bool IsFactory { get; }
    }
}