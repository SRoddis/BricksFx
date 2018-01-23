using System.Collections.Generic;
using BricksFx.Core;
using BricksFx.Core.Module;
using BricksFx.Demo.CommunicationModule;
using BricksFx.DI.Container;

namespace BricksFx.Demo
{
    public class ApplicationPlattform : AbstractPlattform
    {
        public ApplicationPlattform(IContainerAdapter containerAdapter)
            : base(containerAdapter)
        {
        }

        protected override IEnumerable<IBrick> ApplyBricks()
        {
            return new IBrick[]
            {
                new CommunictaionBrick()
            };
        }
    }
}