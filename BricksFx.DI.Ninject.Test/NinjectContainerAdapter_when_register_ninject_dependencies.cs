using BricksFx.Di.Ninject.Test.TestClasses;
using BricksFx.DI;
using BricksFx.DI.Dependency;
using BricksFx.DI.Ninject;
using FluentAssertions;
using Ninject;
using NUnit.Framework;

namespace BricksFx.Di.Ninject.Test
{
    [TestFixture]
    public class NinjectContainerAdapter_when_register_ninject_dependencies
    {
        [SetUp]
        public void SetUp()
        {
            _container = new StandardKernel();

            _adapter = new NinjectContainerAdapter(_container);
        }

        private IKernel _container;

        private NinjectContainerAdapter _adapter;

        [Test]
        public void WHEN_register_by_name_THEN_correct_implementation_is_returned()
        {
            // Arrange
            var dependencies = new IDependency[]
            {
                new NinjectDependency(typeof(ITestClass), typeof(TestClass), LifeTime.OnRequest, typeof(TestClass).Name),
                new NinjectDependency(typeof(ITestClass), typeof(TestClassTwo), LifeTime.OnRequest, typeof(TestClassTwo).Name)
            };

            // Act
            _adapter.Register(dependencies);

            // Assert
            var implementationOne = _container.Get<ITestClass>(typeof(TestClass).Name);
            implementationOne.Should().BeOfType<TestClass>();

            var implementationTwo = _container.Get<ITestClass>(typeof(TestClassTwo).Name);
            implementationTwo.Should().BeOfType<TestClassTwo>();
        }
    }
}