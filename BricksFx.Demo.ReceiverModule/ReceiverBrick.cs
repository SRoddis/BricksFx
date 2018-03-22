using BricksFx.Demo.ReceiverModule.Implementation;
using BricksFx.Module;

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