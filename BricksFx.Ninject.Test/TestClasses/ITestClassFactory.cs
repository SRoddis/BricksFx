namespace BricksFx.Ninject.Test.TestClasses
{
    public interface ITestClassFactory
    {
        ITestClass Create();
        
        ITestClass Create(string name);
    }
}