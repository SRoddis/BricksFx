using BricksFx.DI;
using BricksFx.Ninject;
using BricksFx.Test.TestClasses;
using FluentAssertions;
using Ninject;
using NUnit.Framework;

namespace BricksFx.Test
{
    [TestFixture]
    public class Dependency_when_register_dependency
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
        public void WHEN_register_dependency_THEN_dependency_can_be_found()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new Dependency(typeof(TestClass), LifeTime.OnRequest)};

            // Act
            _adapter.Register(dependencies);

            // Assert
            var instance = _container.Get<TestClass>();
            instance.StringValue = "test";

            var onRequest = _container.Get<TestClass>();
            onRequest.StringValue.Should().Be(null);
        }

        [Test]
        public void WHEN_register_interface_dependency_THEN_dependency_can_be_found_by_interface()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new InterfaceDependency(typeof(ITestClass), typeof(TestClass), LifeTime.OnRequest)};

            // Act
            _adapter.Register(dependencies);

            // Assert
            var instance = _container.Get<ITestClass>();
            instance.StringValue = "test";

            var onRequest = _container.Get<ITestClass>();
            onRequest.StringValue.Should().Be(null);
        }
    }
}