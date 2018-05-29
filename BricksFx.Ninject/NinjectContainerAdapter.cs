using System.Collections.Generic;
using BricksFx.DI;
using BricksFx.DI.Container;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Syntax;
using Ninject.Web.Common;

namespace BricksFx.Ninject
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

                if (dependency is INinjectNamedDependency)
                {
                    HandleNinjectDependency(dependency as INinjectNamedDependency);
                    continue;
                }

                HandleDependency(dependency);
            }
        }

        private void HandleNinjectDependencyFactory(INinjectDependencyFactory dependency)
        {
            var binding = _kernel.Bind(dependency.Interface).ToFactory(dependency.Interface);

            BindLifeTime(dependency, binding);
        }

        private void HandleNinjectDependency(INinjectNamedDependency namedDependency)
        {
            HandleDependency(namedDependency).Named(namedDependency.Name);
        }

        private IBindingNamedWithOrOnSyntax<object> HandleDependency(IDependency dependency)
        {
            var binding = CreateBinding(dependency);

            BindLifeTime(dependency, binding);

            return binding as IBindingNamedWithOrOnSyntax<object>;
        }

        private IBindingWhenInNamedWithOrOnSyntax<object> CreateBinding(IDependency dependency)
        {
            if (dependency is IInterfaceDependency interfaceDependency)
            {
                return _kernel.Bind(interfaceDependency.Interface).To(interfaceDependency.Implementation);
            }
                
            return _kernel.Bind(dependency.Implementation).ToSelf();
        }

        private static void BindLifeTime(IDependency dependency, IBindingWhenInNamedWithOrOnSyntax<object> binding)
        {
            if (dependency.LifeTime == LifeTime.Singleton) binding.InSingletonScope();

            if (dependency.LifeTime == LifeTime.OnRequest) binding.InRequestScope();
        }
    }
}