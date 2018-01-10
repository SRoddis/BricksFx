using System.Collections.Generic;
using BricksFx.DI.Container;
using BricksFx.DI.Dependency;
using Ninject;
using Ninject.Web.Common;

namespace BricksFx.DI.Ninject
{
    public class NinjectContainerAdapter : AbstractContainerAdapter
    {
        private readonly IKernel _kernel;

        public NinjectContainerAdapter(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override void Register(IEnumerable<IDependency> dependencies)
        {
            foreach (var dependency in dependencies)
            {
                var binding = _kernel.Bind(dependency.Interface).To(dependency.Implementation);

                if (dependency.LifeTime == LifeTime.Singleton) binding.InSingletonScope();

                if (dependency.LifeTime == LifeTime.OnRequest) binding.InRequestScope();
            }
        }
    }
}