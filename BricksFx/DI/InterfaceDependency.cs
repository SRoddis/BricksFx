using System;

namespace BricksFx.DI
{
    public class InterfaceDependency : Dependency, IInterfaceDependency
    {
        public InterfaceDependency(Type @interface, Type implementation, LifeTime lifeTime)
            : base(implementation, lifeTime)
        {
            Interface = @interface;
        }

        public Type Interface { get; }
    }
}