using BricksFx.Core.Module;
using BricksFx.Demo.Module.Implementation;
using BricksFx.DI;

namespace BricksFx.Demo.Module
{
    public class ComunictaionBrick : AbstractBrick
    {
        public override void ExposeDependencies()
        {
            Expose<IComunicator, Comunicator>();
            
            Expose<ISaySmth, HelloWorld>();
        }
    }
}