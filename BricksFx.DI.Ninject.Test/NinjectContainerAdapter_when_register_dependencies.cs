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
    public class NinjectContainerAdapter_when_register_dependencies
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
        public void WHEN_register_dependency_THEN_dependency_is_in_container()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new Dependency(typeof(ITestClass), typeof(TestClass), LifeTime.Transient)};

            // Act
            _adapter.Register(dependencies);

            // Assert
            _container.Get<ITestClass>().Should().BeOfType<TestClass>();
        }
    }
}