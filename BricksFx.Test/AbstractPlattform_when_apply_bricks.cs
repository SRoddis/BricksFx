using BricksFx.DI;
using BricksFx.Ninject;
using BricksFx.Test.TestClasses;
using FluentAssertions;
using Ninject;
using NUnit.Framework;

namespace BricksFx.Test
{
    [TestFixture]
    public class AbstractPlattform_when_apply_bricks
    {
        [SetUp]
        public void SetUp()
        {
            _container = new StandardKernel();

            var adapter = new NinjectContainerAdapter(_container);
            
            _plattform = new TestPlattform(adapter);
            
        }

        private IPlattform _plattform;
        
        private IKernel _container;

        [Test]
        public void WHEN_register_dependency_THEN_dependency_can_be_found()
        {
            // Act
            // Arrange
            _plattform.StartUp();

            // Assert
            var instance = _container.Get<ITestClass>();
            instance.StringValue = "test";

            var onRequest = _container.Get<TestClass>();
            onRequest.StringValue.Should().Be(null);
        }
    }
}