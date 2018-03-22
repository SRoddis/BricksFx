using BricksFx.DI;

namespace BricksFx.Ninject
{
    public interface INinjectDependencyFactory : IDependency
    {
        bool IsFactory { get; }
    }
}