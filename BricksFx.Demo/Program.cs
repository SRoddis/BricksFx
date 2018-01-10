using BricksFx.DI.Ninject;
using Ninject;

namespace BricksFx.Demo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var container = new StandardKernel();

            OnStartUp(container);

            var app = container.Get<IApplication>();

            app.Run();
        }

        private static void OnStartUp(IKernel container)
        {
            BindApplicationDependencies(container);

            MountBricks(container);
        }

        private static void BindApplicationDependencies(IKernel container)
        {
            container.Bind<IApplication>().To<Application>();
        }

        private static void MountBricks(IKernel container)
        {
            var adapter = new NinjectContainerAdapter(container);
            var plattform = new ApplicationPlattform(adapter);

            plattform.Mount();
        }
    }
}