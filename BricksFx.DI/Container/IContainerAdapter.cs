using System.Collections.Generic;
using BricksFx.DI.Dependency;

namespace BricksFx.DI.Container
{
    public interface IContainerAdapter
    {
        void Register(IEnumerable<IDependency> dependencies);
    }
}