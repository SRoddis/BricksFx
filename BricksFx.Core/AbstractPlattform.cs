using System.Collections.Generic;
using BricksFx.Core.Module;
using BricksFx.DI.Container;

namespace BricksFx.Core
{
    public abstract class AbstractPlattform : IPlattform
    {
        private readonly IModuleRegistration _moduleRegistration;

        protected AbstractPlattform(IContainerAdapter containerAdapter)
        {
            _moduleRegistration = new ModuleRegistration(containerAdapter);
        }

        public void Mount()
        {
            var modules = PatchModules();

            foreach (var module in modules) module.ProvideDependencies();

            _moduleRegistration.RegisterModules(modules);
        }

        protected abstract IEnumerable<IModule> PatchModules();
    }
}