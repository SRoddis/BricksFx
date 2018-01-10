using System.Collections.Generic;
using BricksFx.DI.Dependency;

namespace BricksFx.Core.Module
{
    public interface IModule
    {
        IList<IDependency> Dependencies { get; }
        
        void ProvideDependencies();
    }
}