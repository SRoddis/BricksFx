using System;

namespace BricksFx.DI
{
    public class Dependency : IDependency
    {
        public Dependency(Type @interface, Type implementation, LifeTime lifeTime)
        {
            Interface = @interface;
            Implementation = implementation;
            LifeTime = lifeTime;
        }

        public Type Interface { get; }

        public Type Implementation { get; }

        public LifeTime LifeTime { get; }
    }
}