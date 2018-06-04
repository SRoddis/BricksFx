using System;
using BricksFx.DI;

namespace BricksFx.Ninject
{
    public interface INinjectProviderDependency : IInterfaceDependency
    {
        Type Provider { get; }
    }
}