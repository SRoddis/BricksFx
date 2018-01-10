using System.Collections.Generic;
using BricksFx.Core;
using BricksFx.Core.Module;
using BricksFx.Demo.Module;
using BricksFx.DI.Container;

namespace BricksFx.Demo
{
    public class DemoPlattform : AbstractPlattform
    {
        public DemoPlattform(IContainerAdapter containerAdapter)
            : base(containerAdapter)
        {
        }

        protected override IEnumerable<IModule> PatchModules()
        {
            return new IModule[]
            {
                new ComunictaionModule()
            };
        }
    }
}