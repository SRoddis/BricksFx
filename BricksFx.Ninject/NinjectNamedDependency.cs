using System;
using BricksFx.DI;

namespace BricksFx.Ninject
{
    public class NinjectNamedDependency : InterfaceDependency, INinjectNamedDependency
    {
        public NinjectNamedDependency(Type @interface, Type implementation, LifeTime lifeTime, string depandanyName)
            : base(@interface, implementation, lifeTime)
        {
            Name = depandanyName;
        }

        public string Name { get; }
    }
}