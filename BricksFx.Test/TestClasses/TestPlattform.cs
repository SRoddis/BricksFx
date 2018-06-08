using System.Collections.Generic;
using BricksFx.DI.Container;
using BricksFx.Module;

namespace BricksFx.Test.TestClasses
{
    public class TestPlattform : AbstractPlattform
    {
        public TestPlattform(IContainerAdapter containerAdapter) : base(containerAdapter)
        {
        }

        protected override IEnumerable<IBrick> ApplyBricks()
        {
            return new[] {new TestBrick()};
        }
    }
}