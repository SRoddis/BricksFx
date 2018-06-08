using Autofac;
using BricksFx.Autofac.Test.TestClasses;
using BricksFx.DI;
using FluentAssertions;
using NUnit.Framework;

namespace BricksFx.Autofac.Test
{
    [TestFixture]
    public class AutofacContainerAdapter_when_register_dependencies_with_lifetime
    {
        [SetUp]
        public void SetUp()
        {
            _builder = new ContainerBuilder();

            _adapter = new AutofacContainerAdapter(_builder);
        }

        private AutofacContainerAdapter _adapter;
        
        private ContainerBuilder _builder;

        [Test]
        public void WHEN_lifetime_is_onRequest_THEN_instance_is_onRequest()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new InterfaceDependency(typeof(ITestClass), typeof(TestClass), LifeTime.OnRequest), };

            // Act
            _adapter.Register(dependencies);
            var container = _builder.Build();

            // Assert
            var instance = container.Resolve<ITestClass>();
            instance.StringValue = "test";

            var onRequest = container.Resolve<ITestClass>();
            onRequest.StringValue.Should().Be(null);
        }

        [Test]
        public void WHEN_lifetime_is_singelton_THEN_instance_is_singelton()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new InterfaceDependency(typeof(ITestClass), typeof(TestClass), LifeTime.Singleton), };

            // Act
            _adapter.Register(dependencies);
            var container = _builder.Build();

            // Assert
            var instance = container.Resolve<ITestClass>();
            instance.StringValue = "test";

            var singelton = container.Resolve<ITestClass>();
            singelton.StringValue.Should().Be("test");
        }

        [Test]
        public void WHEN_lifetime_is_transient_THEN_instance_is_transient()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new InterfaceDependency(typeof(ITestClass), typeof(TestClass), LifeTime.Transient), };

            // Act
            _adapter.Register(dependencies);
            var container = _builder.Build();

            // Assert
            var instance = container.Resolve<ITestClass>();
            instance.StringValue = "test";

            var transient = container.Resolve<ITestClass>();
            transient.StringValue.Should().Be(null);
        }

        [Test]
        public void WHEN_register_dependency_THEN_dependency_is_in_container()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new InterfaceDependency(typeof(ITestClass), typeof(TestClass), LifeTime.Transient)};

            // Act
            _adapter.Register(dependencies);
            var container = _builder.Build();

            // Assert
            container.Resolve<ITestClass>().Should().BeOfType<TestClass>();
        }
    }
}