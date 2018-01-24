nuget install NUnit.Runners -Version 3.2.1 -OutputDirectory tools
nuget install OpenCover -Version 4.6.519 -OutputDirectory tools
nuget install coveralls.net -Version 0.6.0 -OutputDirectory tools
 
.\tools\OpenCover.4.6.519\tools\OpenCover.Console.exe -register:user -target:.\tools\NUnit.ConsoleRunner.3.2.1\tools\nunit3-console.exe -targetargs:".\BricksFx.Core.Test\bin\Release\BricksFx.Core.Test.dll .\BricksFx.DI.Ninject.Test\bin\Release\BricksFx.DI.Ninject.Test.dll" -filter:"+[BricksFx.*]* -[*.Test]*" 
 
.\tools\coveralls.net.0.6.0\tools\csmacnz.Coveralls.exe --opencover -i .\results.xml