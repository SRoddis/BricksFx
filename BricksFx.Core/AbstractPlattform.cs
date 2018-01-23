using System.Collections.Generic;
using System.Linq;
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

        public void StartUp()
        {
            var bricks = ApplyBricks().ToList();

            foreach (var brick in bricks) brick.BindDependencies();

            _brickRegistration.Register(bricks);
        }

        protected abstract IEnumerable<IBrick> ApplyBricks();
    }
}