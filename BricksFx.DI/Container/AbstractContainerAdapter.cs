using System.Collections.Generic;
using BricksFx.DI.Dependency;

namespace BricksFx.DI.Container
{
    public abstract class AbstractContainerAdapter : IContainerAdapter
    {
        public abstract void Register(IEnumerable<IDependency> dependencies);
    }
}