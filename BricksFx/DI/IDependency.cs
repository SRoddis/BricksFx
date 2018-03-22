using System;

namespace BricksFx.DI
{
    public interface IDependency
    {
        Type Interface { get; }

        Type Implementation { get; }

        LifeTime LifeTime { get; }
    }
}