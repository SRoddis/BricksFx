using System.Collections.Generic;
using BricksFx.DI.Container;
using BricksFx.DI.Dependency;

namespace BricksFx.Core.Module
{
    public class ModuleRegistration : IModuleRegistration
    {
        private readonly IContainerAdapter _containerAdapter;

        public ModuleRegistration(IContainerAdapter containerAdapter)
        {
            _containerAdapter = containerAdapter;
        }

        public void RegisterModules(IEnumerable<IModule> modules)
        {
            var mergedDependencies = new List<IDependency>();

            foreach (var module in modules) mergedDependencies.AddRange(module.Dependencies);

            _containerAdapter.Register(mergedDependencies);
        }
    }
}