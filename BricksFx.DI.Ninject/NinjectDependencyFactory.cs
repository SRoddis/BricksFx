using System;

namespace BricksFx.DI.Ninject
{
    public class NinjectDependencyFactory : Dependency.Dependency, INinjectDependencyFactory
    {
        public NinjectDependencyFactory(Type @interface)
            : base(@interface, null, LifeTime.Singleton)
        {
            IsFactory = true;
        }

        public bool IsFactory { get; }
    }
}