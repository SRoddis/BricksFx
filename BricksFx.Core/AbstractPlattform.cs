using System.Collections.Generic;
using BricksFx.Core.Module;
using BricksFx.DI.Container;

namespace BricksFx.Core
{
    public abstract class AbstractPlattform : IPlattform
    {
        private readonly IBrickRegistration _brickRegistration;

        protected AbstractPlattform(IContainerAdapter containerAdapter)
        {
            _brickRegistration = new BrickRegistration(containerAdapter);
        }

        public void Mount()
        {
            var bricks = PatchBricks();

            foreach (var brick in bricks) brick.ExposeDependencies();

            _brickRegistration.Register(bricks);
        }

        protected abstract IEnumerable<IBrick> PatchBricks();
    }
}