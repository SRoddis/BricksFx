using System.Collections.Generic;

namespace BricksFx.Core.Module
{
    public interface IModuleRegistration
    {
        void RegisterModules(IEnumerable<IModule> modules);
    }
}