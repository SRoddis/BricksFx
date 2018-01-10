using System;
using BricksFx.Demo.Module.Implementation;

namespace BricksFx.Demo
{
    public class Application : IApplication
    {
        private readonly IComunicator _comunicator;

        public Application(IComunicator comunicator)
        {
            _comunicator = comunicator;
        }

        public void Run()
        {
            Console.WriteLine(_comunicator.Comunicate());
            Console.ReadLine();
        }
    }

    public interface IApplication
    {
        void Run();
    }
}