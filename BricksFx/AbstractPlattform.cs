using System.Collections.Generic;
using System.Linq;
using BricksFx.DI.Container;
using BricksFx.Module;

namespace BricksFx
{
    public abstract class AbstractPlattform : IPlattform
    {
        private readonly IBrickRegistration _brickRegistration;

        protected AbstractPlattform(IContainerAdapter containerAdapter)
        {
            _brickRegistration = new BrickRegistration(containerAdapter);
        }

        public void StartUp()
        {
            var bricks = ApplyBricks().ToList();

            foreach (var brick in bricks) brick.BindDependencies();

            _brickRegistration.Register(bricks);
        }

        protected abstract IEnumerable<IBrick> ApplyBricks();
    }
}