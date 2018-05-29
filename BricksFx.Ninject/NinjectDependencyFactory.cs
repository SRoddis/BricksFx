using System;
using BricksFx.DI;

namespace BricksFx.Ninject
{
    public class NinjectDependencyFactory : InterfaceDependency, INinjectDependencyFactory
    {
        public NinjectDependencyFactory(Type @interface)
            : base(@interface, null, LifeTime.Singleton)
        {
            IsFactory = true;
        }

        public bool IsFactory { get; }
    }
}