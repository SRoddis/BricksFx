using BricksFx.Core.Module;
using BricksFx.Demo.CommunicatorModule.Implementation;

namespace BricksFx.Demo.CommunicatorModule
{
    public class CommunicatorBrick : Brick
    {
        public override void BindDependencies()
        {
            Bind<ICommunicator, Communicator>();
            Bind<ISaySmth, HelloWorld>();
        }
    }
}