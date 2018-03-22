using System.Collections.Generic;

namespace BricksFx.DI.Container
{
    public abstract class AbstractContainerAdapter : IContainerAdapter
    {
        public abstract void Register(IEnumerable<IDependency> dependencies);
    }
}