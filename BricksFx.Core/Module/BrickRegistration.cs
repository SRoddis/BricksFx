using System.Collections.Generic;
using System.Linq;
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
            var mergedDependencies = bricks.SelectMany(b => b.Dependencies);

            _containerAdapter.Register(mergedDependencies);
        }
    }
}