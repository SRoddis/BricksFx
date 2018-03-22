using System.Collections.Generic;

namespace BricksFx.DI.Container
{
    public interface IContainerAdapter
    {
        void Register(IEnumerable<IDependency> dependencies);
    }
}