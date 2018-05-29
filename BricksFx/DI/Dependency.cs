using System;

namespace BricksFx.DI
{
    public class Dependency : IDependency
    {
        public Dependency(Type implementation, LifeTime lifeTime)
        {
            Implementation = implementation;
            LifeTime = lifeTime;
        }

        public Type Implementation { get; }

        public LifeTime LifeTime { get; }
    }
}