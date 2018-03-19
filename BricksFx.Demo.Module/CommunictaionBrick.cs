using BricksFx.Core.Module;
using BricksFx.Demo.CommunicationModule.Implementation;

namespace BricksFx.Demo.CommunicationModule
{
    public class CommunictaionBrick : Brick
    {
        public override void BindDependencies()
        {
            Bind<ICommunicator, Communicator>();
            Bind<ISaySmth, HelloWorld>();
        }
    }
}