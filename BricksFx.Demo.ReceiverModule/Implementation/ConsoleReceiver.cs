using System;

namespace BricksFx.Demo.ReceiverModule.Implementation
{
    internal class ConsoleReceiver : IReceiver
    {
        public void Receive(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}