using System.Collections.Generic;
using BricksFx.DI.Container;
using BricksFx.DI.Dependency;

namespace BricksFx.Core.Module
{
    public class BrickRegistration : IBrickRegistration
    {
        private readonly IContainerAdapter _containerAdapter;

        public BrickRegistration(IContainerAdapter containerAdapter)
        {
            _containerAdapter = containerAdapter;
        }

        public void Register(IEnumerable<IBrick> bricks)
        {
            var mergedDependencies = new List<IDependency>();

            foreach (var brick in bricks) mergedDependencies.AddRange(brick.Dependencies);

            _containerAdapter.Register(mergedDependencies);
        }
    }
}