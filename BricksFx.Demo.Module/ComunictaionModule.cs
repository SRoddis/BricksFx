using BricksFx.Core.Module;
using BricksFx.Demo.Module.Implementation;
using BricksFx.DI;

namespace BricksFx.Demo.Module
{
    public class ComunictaionModule : AbstractModule
    {
        public override void ProvideDependencies()
        {
            RegisterDependency<IComunicator, Comunicator>();
            
            RegisterDependency<ISaySmth, HelloWorld>();
        }
    }
}