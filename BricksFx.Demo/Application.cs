using System;
using BricksFx.Demo.CommunicatorModule.Implementation;
using BricksFx.Demo.ReceiverModule.Implementation;

namespace BricksFx.Demo
{
    public class Application : IApplication
    {
        private readonly ICommunicator _communicator;
        
        private readonly IReceiver _receiver;

        public Application(ICommunicator communicator, IReceiver receiver)
        {
            _communicator = communicator;
            _receiver = receiver;
        }

        public void Run()
        {
            var message = _communicator.Comunicate();

            _receiver.Receive(message);
        }
    }

    public interface IApplication
    {
        void Run();
    }
}