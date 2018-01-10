using System.Collections.Generic;
using BricksFx.Core;
using BricksFx.Core.Module;
using BricksFx.Demo.Module;
using BricksFx.DI.Container;

namespace BricksFx.Demo
{
    public class ApplicationPlattform : AbstractPlattform
    {
        public ApplicationPlattform(IContainerAdapter containerAdapter)
            : base(containerAdapter)
        {
        }

        protected override IEnumerable<IBrick> PatchBricks()
        {
            return new IBrick[]
            {
                new ComunictaionBrick()
            };
        }
    }
}