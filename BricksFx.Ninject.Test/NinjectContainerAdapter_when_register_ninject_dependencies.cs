using BricksFx.DI;
using BricksFx.Ninject.Test.TestClasses;
using FluentAssertions;
using Ninject;
using NUnit.Framework;

namespace BricksFx.Ninject.Test
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
        public void WHEN_register_by_name_and_use_factory_THEN_correct_implementation_is_returned()
        {
            // Arrange
            var dependencies = new IDependency[]
            {
                new InterfaceDependency(typeof(ITestClassFactory), typeof(TestClassFactory), LifeTime.Singleton),
                new NinjectNamedDependency(typeof(ITestClass), typeof(TestClass), LifeTime.OnRequest, typeof(TestClass).Name),
                new NinjectNamedDependency(typeof(ITestClass), typeof(TestClassTwo), LifeTime.OnRequest, typeof(TestClassTwo).Name)
            };

            // Act
            _adapter.Register(dependencies);

            // Assert
            var factory = _container.Get<ITestClassFactory>();

            var implementationOne = factory.Create(typeof(TestClass).Name);
            implementationOne.Should().BeOfType<TestClass>();

            var implementationTwo = factory.Create(typeof(TestClassTwo).Name);
            implementationTwo.Should().BeOfType<TestClassTwo>();
        }

        [Test]
        public void WHEN_use_auto_factory_THEN_correct_implementation_is_returned()
        {
            // Arrange
            var dependencies = new IDependency[]
            {
                new NinjectFactoryDependency(typeof(ITestClassFactory)),
                new InterfaceDependency(typeof(ITestClass), typeof(TestClass), LifeTime.OnRequest)
            };

            // Act
            _adapter.Register(dependencies);

            // Assert
            var factory = _container.Get<ITestClassFactory>();

            var implementation = factory.Create();
            implementation.Should().BeOfType<TestClass>();
        }
        
        [Test]
        public void WHEN_use_provider_THEN_correct_implementation_is_returned()
        {
            // Arrange
            var dependencies = new IDependency[]
            {
                new NinjectProviderDependency(typeof(ITestClass), typeof(TestClassProvider), LifeTime.OnRequest), 
            };

            // Act
            _adapter.Register(dependencies);

            // Assert
            var implementation = _container.Get<ITestClass>();

            implementation.Should().BeOfType<TestClass>();
        }
    }
}