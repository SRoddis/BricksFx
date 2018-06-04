using System;
using BricksFx.DI;

namespace BricksFx.Ninject
{
    public class NinjectProviderDependency : InterfaceDependency, INinjectProviderDependency
    {
        public NinjectProviderDependency(Type @interface, Type provider, LifeTime lifeTime)
            : base(@interface, null, lifeTime)
        {
            Provider = provider;
        }

        public Type Provider { get; }
    }
}