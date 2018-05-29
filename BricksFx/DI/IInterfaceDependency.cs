using System;

namespace BricksFx.DI
{
    public interface IInterfaceDependency : IDependency
    {
        Type Interface { get; }
    }
}