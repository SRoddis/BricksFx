# BricksFx

[![Build status](https://ci.appveyor.com/api/projects/status/ui3ylss69px8owb1/branch/master?svg=true)](https://ci.appveyor.com/project/SRoddis/bricksfx/branch/master) [![Coverage Status](https://coveralls.io/repos/github/SRoddis/BricksFx/badge.svg?branch=master)](https://coveralls.io/github/SRoddis/BricksFx?branch=master)

`"Keep your code away from your Framework and DI-Container"`

* What? `BricksFx` will help you to cut your Application in to small Modules (Bricks) and you can easily reused your Code in another Project.  
* How? Just seed up a `IPlattform` where you can stick your Bricks together. Just like Lego-Bricks... KISS!
* Why? Because I'am a Programmer and everyone is talking about reusability, but I am honest... I have rarely seen Programmers reusing Code. The most of the Time it was to deep embedded.

# Installation

<!--- 

Install via nuget https://www.nuget.org/packages/BricksFx.Core

Install via nuget https://www.nuget.org/packages/BricksFx.DI

(Optional)

Install via nuget https://www.nuget.org/packages/BricksFx.DI.Ninject 
```
PM> Install-Package BricksFx 

```

-->

# How to use

1. Initialize `BricksFx` befor the `Application`.

    ```csharp
    
    // Implement your ApplicationPlattform where can register your Bricks (Modules)
    public class ApplicationPlattform : AbstractPlattform
    {
        public ApplicationPlattform(IContainerAdapter containerAdapter)
            : base(containerAdapter)
        {
        }

        protected override IEnumerable<IBrick> ApplyBricks()
        {
            // Register your Bricks (Modules)
            return new IBrick[]
            {
                new CommunictaionBrick()
            };
        }
    }
    
    ```
    
    ```csharp
        
    public class Program
    {
    
        // Excample with ninject
        var container = new StandardKernel();
        container.Bind<IApplication>().To<Application>();
    
        // BricksFx - Setup your DIContainerAdapter and Plattform
        container.Bind<IContainerAdapter>().To<NinjectContainerAdapter>();
        container.Bind<IPlattform>().To<ApplicationPlattform>();

        // BricksFx - StartUp the Plattform to register all your dependencies
        var plattform = container.Get<IPlattform>();
        plattform.StartUp();

        // Run your application/webservice/webapp/app what ever! ;o)        
        var app = container.Get<IApplication>();
        app.Run();
    }
    
    ```
    
2. Create a Brick (Module) and define your dependencies. 

    ```csharp
    
    // Brick (Module)
    public class CommunictaionBrick : Brick
    {
        public override void BindDependencies()
        {
            Bind<ICommunicator, Communicator>();
            Bind<ISaySmth, HelloWorld>();
        }
    }
    
    ```
    
    ```csharp
    
    // Rest of the Implementation
    public interface ISaySmth
    {
        string Say();
    }
    
    ```
    
    ```csharp
    
    public interface ICommunicator
    {
        string Comunicate();
    }
    
    ```
    
    ```csharp
    
    internal class HelloWorld : ISaySmth
    {      
        public string Say()
        {
            return "Hello World!";
        }
    }
    
    ```
    
    ```csharp
    
    internal class Communicator : ICommunicator
    {
        private readonly ISaySmth _saySmth;

        public Communicator(ISaySmth saySmth)
        {
            _saySmth = saySmth;
        }

        public string Comunicate()
        {
            return _saySmth.Say();
        }
    }
        
    ```
    
3. Please have a look in the Demo. When you have questions, send me a message or open a issue. 
    
    ## Copyright
    
    Copyright © 2018 Sean Roddis
    
    ## License
    
    BricksFx is licensed under [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form"). Refer to LICENSE.txt for more information.