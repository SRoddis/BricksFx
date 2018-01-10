using System;
using BricksFx.Demo.Module.Implementation;
using BricksFx.DI.Ninject;
using Ninject;

namespace BricksFx.Demo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var container = new StandardKernel();
           
            var adapter = new NinjectContainerAdapter(container);
            
            var bricksApp = new DemoPlattform(adapter);
            bricksApp.Mount();
            
            var comunicator = container.Get<IComunicator>();
            
            Console.WriteLine(comunicator.Comunicate());
            Console.ReadLine();
        }
    }
}