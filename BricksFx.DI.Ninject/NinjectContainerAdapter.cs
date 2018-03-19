using System.Collections.Generic;
using BricksFx.DI.Container;
using BricksFx.DI.Dependency;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Syntax;
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
                if (dependency is INinjectDependencyFactory)
                {
                    HandleNinjectDependencyFactory(dependency as INinjectDependencyFactory);
                    continue;
                }

                if (dependency is INinjectDependency)
                {
                    HandleNinjectDependency(dependency as INinjectDependency);
                    continue;
                }

                HandleDependency(dependency);
            }
        }

        private void HandleNinjectDependencyFactory(INinjectDependencyFactory dependency)
        {
            _kernel.Bind(dependency.Interface).ToFactory(dependency.Interface);
        }

        private void HandleNinjectDependency(INinjectDependency dependency)
        {
            HandleDependency(dependency).Named(dependency.Name);
        }

        private IBindingNamedWithOrOnSyntax<object> HandleDependency(IDependency dependency)
        {
            var binding = _kernel.Bind(dependency.Interface).To(dependency.Implementation);

            if (dependency.LifeTime == LifeTime.Singleton) binding.InSingletonScope();

            if (dependency.LifeTime == LifeTime.OnRequest) binding.InRequestScope();

            return binding as IBindingNamedWithOrOnSyntax<object>;
        }
    }
}