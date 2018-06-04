using System.Collections.Generic;
using Autofac;
using Autofac.Builder;
using BricksFx.DI;
using BricksFx.DI.Container;

namespace BricksFx.Autofac
{
    public class AutofacContainerAdapter : AbstractContainerAdapter
    {
        private readonly ContainerBuilder _builder;

        public AutofacContainerAdapter(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public override void Register(IEnumerable<IDependency> dependencies)
        {
            foreach (var dependency in dependencies) HandleDependency(dependency);
        }

        private void HandleDependency(IDependency dependency)
        {
            var binding = _builder.RegisterType(dependency.Implementation);

            if (dependency is IInterfaceDependency interfaceDependency) binding.As(interfaceDependency.Interface);

            BindLifeTime(dependency, binding);
        }

        private static void BindLifeTime(
            IDependency dependency,
            IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> binding)
        {
            if (dependency.LifeTime is LifeTime.Singleton) binding.SingleInstance();

            if (dependency.LifeTime is LifeTime.OnRequest) binding.InstancePerRequest();
        }
    }
}