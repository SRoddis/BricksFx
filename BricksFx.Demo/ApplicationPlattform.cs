using System.Collections.Generic;
using BricksFx.Demo.CommunicatorModule;
using BricksFx.Demo.ReceiverModule;
using BricksFx.DI.Container;
using BricksFx.Module;

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
                new CommunicatorBrick(),
                new ReceiverBrick()
            };
        }
    }
}