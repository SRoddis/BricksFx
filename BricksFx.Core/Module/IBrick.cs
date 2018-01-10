using System.Collections.Generic;
using BricksFx.DI.Dependency;

namespace BricksFx.Core.Module
{
    public interface IBrick
    {
        IList<IDependency> Dependencies { get; }
        
        void ExposeDependencies();
    }
}