using System;

namespace BricksFx.DI
{
    public interface IDependency
    {
        Type Implementation { get; }

        LifeTime LifeTime { get; }
    }
}