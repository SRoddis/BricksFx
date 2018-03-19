using System;

namespace BricksFx.DI.Ninject
{
    public class NinjectDependency : Dependency.Dependency, INinjectDependency
    {
        private NinjectDependency(Type @interface, Type implementation, LifeTime lifeTime)
            : base(@interface, implementation, lifeTime)
        {
        }

        public NinjectDependency(Type @interface, Type implementation, LifeTime lifeTime, string depandanyName)
            : this(@interface, implementation, lifeTime)
        {
            Name = depandanyName;
        }

        public NinjectDependency(Type @interface)
            : this(@interface, null, LifeTime.Transient)
        {
            IsFactory = true;
        }

        public string Name { get; }

        public bool IsFactory { get; }
    }
}