﻿using BricksFx.Di.Ninject.Test.TestClasses;
using BricksFx.DI;
using BricksFx.DI.Dependency;
using BricksFx.DI.Ninject;
using FluentAssertions;
using Ninject;
using NUnit.Framework;

namespace BricksFx.Di.Ninject.Test
{
    [TestFixture]
    public class NinjectContainerAdapter_when_register_ninject_dependencies_with_lifetime
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
        public void WHEN_lifetime_is_onRequest_THEN_instance_is_onRequest()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new NinjectDependency(typeof(ITestClass), typeof(TestClass), LifeTime.OnRequest, typeof(TestClass).Name)};

            // Act
            _adapter.Register(dependencies);

            // Assert
            var instance = _container.Get<ITestClass>();
            instance.StringValue = "test";

            var onRequest = _container.Get<ITestClass>();
            onRequest.StringValue.Should().Be(null);
        }

        [Test]
        public void WHEN_lifetime_is_singelton_THEN_instance_is_singelton()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new NinjectDependency(typeof(ITestClass), typeof(TestClass), LifeTime.Singleton, typeof(TestClass).Name)};

            // Act
            _adapter.Register(dependencies);

            // Assert
            var instance = _container.Get<ITestClass>();
            instance.StringValue = "test";

            var singelton = _container.Get<ITestClass>();
            singelton.StringValue.Should().Be("test");
        }

        [Test]
        public void WHEN_lifetime_is_transient_THEN_instance_is_transient()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new NinjectDependency(typeof(ITestClass), typeof(TestClass), LifeTime.Transient, typeof(TestClass).Name)};

            // Act
            _adapter.Register(dependencies);

            // Assert
            var instance = _container.Get<ITestClass>();
            instance.StringValue = "test";

            var transient = _container.Get<ITestClass>();
            transient.StringValue.Should().Be(null);
        }

        [Test]
        public void WHEN_register_dependency_THEN_dependency_is_in_container()
        {
            // Arrange
            var dependencies = new IDependency[]
                {new NinjectDependency(typeof(ITestClass), typeof(TestClass), LifeTime.Transient, typeof(TestClass).Name)};

            // Act
            _adapter.Register(dependencies);

            // Assert
            _container.Get<ITestClass>().Should().BeOfType<TestClass>();
        }
    }
}