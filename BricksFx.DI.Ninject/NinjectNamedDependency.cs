using System;

namespace BricksFx.DI.Ninject
{
    public class NinjectNamedDependency : Dependency.Dependency, INinjectNamedDependency
    {
        public NinjectNamedDependency(Type @interface, Type implementation, LifeTime lifeTime, string depandanyName)
            : base(@interface, implementation, lifeTime)
        {
            Name = depandanyName;
        }

        public string Name { get; }
    }
}