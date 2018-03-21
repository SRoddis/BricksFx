using BricksFx.Core.Module;
using BricksFx.Demo.ReceiverModule.Implementation;

namespace BricksFx.Demo.ReceiverModule
{
    public class ReceiverBrick : Brick
    {
        public override void BindDependencies()
        {
            Bind<IReceiver, ConsoleReceiver>();
        }
    }
}