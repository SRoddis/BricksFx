using BricksFx.Core.Module;

namespace BricksFx.DI.Ninject
{
    public abstract class NinjectBrick : Brick
    {
        protected void Bind<TInterface, TClass>(string dependancyName, LifeTime lifeTime = LifeTime.Transient)
            where TInterface : class
            where TClass : class
        {
            Dependencies.Add(new NinjectNamedDependency(typeof(TInterface), typeof(TClass), lifeTime, dependancyName));
        }

        protected void BindFactory<TInterface, TClass>() where TInterface : class
        {
            Dependencies.Add(new NinjectDependencyFactory(typeof(TInterface)));
        }
    }
}