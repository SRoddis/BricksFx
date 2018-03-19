using Ninject;

namespace BricksFx.Di.Ninject.Test.TestClasses
{
    public class TestClassFactory : ITestClassFactory
    {
        private readonly IKernel _kernel;

        public TestClassFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public ITestClass Create()
        {
            return _kernel.Get<ITestClass>();
        }

        public ITestClass Create(string name)
        {
            return _kernel.Get<ITestClass>(name);
        }
    }
}