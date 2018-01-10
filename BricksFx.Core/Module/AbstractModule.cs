using System.Collections.Generic;
using BricksFx.DI;
using BricksFx.DI.Dependency;

namespace BricksFx.Core.Module
{
    public abstract class AbstractModule : IModule
    {
        protected AbstractModule()
        {
            Dependencies = new List<IDependency>();
        }

        public IList<IDependency> Dependencies { get; }

        protected void RegisterDependency<TInterface, TClass>(LifeTime lifeTime = LifeTime.Transient)
            where TInterface : class
            where TClass : class
        {
            Dependencies.Add(new Dependency(typeof(TInterface), typeof(TClass), lifeTime));
        }

        public abstract void ProvideDependencies();
    }
}