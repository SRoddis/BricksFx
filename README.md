# BricksFx

[![Build status](https://ci.appveyor.com/api/projects/status/ui3ylss69px8owb1/branch/master?svg=true)](https://ci.appveyor.com/project/SRoddis/bricksfx/branch/master) [![Coverage Status](https://coveralls.io/repos/github/SRoddis/BricksFx/badge.svg?branch=master)](https://coveralls.io/github/SRoddis/BricksFx?branch=master)

---

Build your Application Brick by Brick

---

<p align="center">
    <img src="https://raw.githubusercontent.com/SRoddis/BricksFx/master/giphy.gif" width="200">
</p>

---

# Introduction

### What?

`BricksFx` is a small library, which will help you to structure your code and make it reusable in other projects.
`BricksFx` allows you to write small and handy `Bricks` (modules) that can be seed up easily in new or old projects.
The key is to keep your business code (logic) away from used frameworks or dependency-injection-containers.

### Why? 
Because you should love your code and tread it like home.

`BricksFx` brings you the possibility to describe your code "`Bricks`".
You can describe all the interfaces you want to expose and keep the implementation internal.
The binding mechanism makes it easy to add your code to an existing or new project.
The common DI-containers are supported. If you want to use a different one,
then you can write a custom `ContainerAdapter`. 

And yes, that means you have to use interfaces. But that is what you should do… always! 

### How?
Define a `Brick` for the code you want to write, bind the dependencies you want to expose and seed
up an `IPlattform` where you can stick new and old `Bricks` (modules) together. 
It should be as easy as building LEGO-Bricks… KISS!


# Installation

Install via nuget https://www.nuget.org/packages/BricksFx

```
PM> Install-Package BricksFx 
```

(Optional)

Install via nuget https://www.nuget.org/packages/BricksFx.Ninject 

```
PM> Install-Package BricksFx.Ninject
```

# How to use

1. Initialize `BricksFx` befor the `Application`.

    ```csharp
    
    // Implement your ApplicationPlattform. In the ApplicationPlattform you can register your Bricks (Modules).
    public class ApplicationPlattform : AbstractPlattform
    {
        public ApplicationPlattform(IContainerAdapter containerAdapter)
            : base(containerAdapter)
        {
        }

        protected override IEnumerable<IBrick> ApplyBricks()
        {
            // Register your Bricks (Modules). How to create a Brick, please see "2. Create a Brick"
            return new IBrick[]
            {
                new CommunicatorBrick(),
                new ReceiverBrick()
            };
        }
    }
    
    ```
    
    ```csharp
        
    public class Program
    {
    
        // Excample with Ninject
        var container = new StandardKernel();
        container.Bind<IApplication>().To<Application>();
    
        // BricksFx - Setup your DIContainerAdapter and Plattform
        container.Bind<IContainerAdapter>().To<NinjectContainerAdapter>();
        container.Bind<IPlattform>().To<ApplicationPlattform>();

        // BricksFx - StartUp the Plattform to register all the dependencies of the added Bricks
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
    
    public class ReceiverBrick : Brick
    {
        public override void BindDependencies()
        {
            Bind<IReceiver, ConsoleReceiver>();
        }
    }
    
    ```
        
    ```csharp
    
    // Implementation of the Brick (Module)
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
    
    internal class ConsoleReceiver : IReceiver
    {
        public void Receive(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
        
    ```
    
    ```csharp
    
    // The defined dependencies can now be injected in the Application
    public class Application : IApplication
    {
        private readonly ICommunicator _communicator;
        
        private readonly IReceiver _receiver;

        public Application(ICommunicator communicator, IReceiver receiver)
        {
            _communicator = communicator;
            _receiver = receiver;
        }

        public void Run()
        {
            var message = _communicator.Comunicate();

            _receiver.Receive(message);
        }
    }
        
    ```
        
    
3. Please have a look at the Demo. If you have questions, send me a message or open a issue in this repository. 
    
    ## Copyright
    
    Copyright © 2018 Sean Roddis
    
    ## License
    
    BricksFx is licensed under [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form"). Refer to LICENSE.txt for more information.