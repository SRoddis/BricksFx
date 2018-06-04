using System;
using BricksFx.DI;

namespace BricksFx.Ninject
{
    public class NinjectFactoryDependency : InterfaceDependency, INinjectFactoryDependency
    {
        public NinjectFactoryDependency(Type @interface)
            : base(@interface, null, LifeTime.Singleton)
        {
            IsFactory = true;
        }

        public bool IsFactory { get; }
    }
}