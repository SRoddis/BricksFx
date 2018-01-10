using BricksFx.Core.Module;
using BricksFx.Demo.CommunicationModule.Implementation;

namespace BricksFx.Demo.CommunicationModule
{
    public class CommunictaionBrick : AbstractBrick
    {
        public override void ExposeDependencies()
        {
            Expose<ICommunicator, Communicator>();
            Expose<ISaySmth, HelloWorld>();
        }
    }
}