using System;

namespace BricksFx.DI.Dependency
{
    public interface IDependency
    {
        Type Interface { get; }

        Type Implementation { get; }

        LifeTime LifeTime { get; }
    }
}