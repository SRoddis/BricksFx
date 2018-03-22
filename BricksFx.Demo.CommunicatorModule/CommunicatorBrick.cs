using BricksFx.Demo.CommunicatorModule.Implementation;
using BricksFx.Module;

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