using System;
using BricksFx.Demo.CommunicationModule.Implementation;

namespace BricksFx.Demo
{
    public class Application : IApplication
    {
        private readonly ICommunicator _communicator;

        public Application(ICommunicator communicator)
        {
            _communicator = communicator;
        }

        public void Run()
        {
            Console.WriteLine(_communicator.Comunicate());
            Console.ReadLine();
        }
    }

    public interface IApplication
    {
        void Run();
    }
}