* `git checkout Demo1`
* First of all we are going to need a bootstrapper
  * Invoke-WebRequest http://cakebuild.net/bootstrapper/windows -OutFile build.ps1
* Next we are going to need a build.cake file
  * Create the file and add template

```
var target = Argument("target", "Default");

Task("NuGet-Package-Restore")
    .Does(() =>
{

});

Task("Default")
  .IsDependentOn("NuGet-Package-Restore");

RunTarget(target);
```

  * Add NuGetRestore Alias

  ```
    NuGetRestore("./Source/Gep13.Cake.Sample.WebApplication.sln");
  ```
