using BricksFx.DI;
using BricksFx.Module;

namespace BricksFx.Autofac
{
    public abstract class AutofacBrick : Brick
    {
        protected void Bind<TInterface>(object instance, LifeTime lifeTime = LifeTime.Transient)
            where TInterface : class
        {
            Dependencies.Add(new AutofacInstanceDependency(typeof(TInterface), instance, lifeTime));
        }
    }
}