using System.Collections.Generic;
using BricksFx.DI;

namespace BricksFx.Module
{
    public interface IBrick
    {
        IList<IDependency> Dependencies { get; }
        
        void BindDependencies();
    }
}