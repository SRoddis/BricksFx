using System.Collections.Generic;
using System.Linq;
using BricksFx.DI.Container;

namespace BricksFx.Module
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