using System;
using Ninject.Activation;

namespace BricksFx.Ninject.Test.TestClasses
{
    public class TestClassProvider : Provider<TestClass>
    {
        protected override TestClass CreateInstance(IContext context)
        {
            return new TestClass();
        }
    }
}