using System;
using BricksFx.DI;

namespace BricksFx.Autofac
{
    public class AutofacInstanceDependency : InterfaceDependency, IAutofacInstanceDependency
    {
        public AutofacInstanceDependency(Type @interface, object instance, LifeTime lifeTime) : base(@interface, null,
            lifeTime)
        {
            Instance = instance;
        }

        public object Instance { get; }
    }
}