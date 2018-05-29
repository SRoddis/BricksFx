using System.Collections.Generic;
using BricksFx.DI;

namespace BricksFx.Module
{
    public abstract class Brick : IBrick
    {
        protected Brick()
        {
            Dependencies = new List<IDependency>();
        }

        public IList<IDependency> Dependencies { get; }

        protected void Bind<TInterface, TClass>(LifeTime lifeTime = LifeTime.Transient)
            where TInterface : class
            where TClass : class
        {
            Dependencies.Add(new InterfaceDependency(typeof(TInterface), typeof(TClass), lifeTime));
        }

        public abstract void BindDependencies();
    }
}