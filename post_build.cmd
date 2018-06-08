nuget install NUnit.Runners -Version 3.2.1 -OutputDirectory tools
nuget install OpenCover -Version 4.6.519 -OutputDirectory tools
nuget install coveralls.net -Version 0.6.0 -OutputDirectory tools
 
.\tools\OpenCover.4.6.519\tools\OpenCover.Console.exe ^
 -register:user ^
 -target:.\tools\NUnit.ConsoleRunner.3.2.1\tools\nunit3-console.exe ^
 -targetargs:".\BricksFx.Test\bin\Release\BricksFx.Test.dll .\BricksFx.Ninject.Test\bin\Release\BricksFx.Ninject.Test.dll .\BricksFx.Autofac.Test\bin\Release\BricksFx.Autofac.Test.dll" ^
 -filter:"+[BricksFx*]*" 
 
.\tools\coveralls.net.0.6.0\tools\csmacnz.Coveralls.exe --opencover -i .\results.xml