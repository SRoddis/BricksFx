using BricksFx.Module;

namespace BricksFx.Test.TestClasses
{
    public class TestBrick : Brick
    {
        public override void BindDependencies()
        {
            Bind<ITestClass, TestClass>();
        }
    }
}