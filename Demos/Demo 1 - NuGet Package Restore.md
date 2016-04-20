* `git checkout Demo1`
* First of all we are going to need a bootstrapper.  Normally, when on Windows, this would be done by doing this:

```
Invoke-WebRequest http://cakebuild.net/bootstrapper/windows -OutFile build.ps1
```

* But we are going to use this, so that we can use the offline installation:

```
Invoke-WebRequest http://localhost:8081/repository/cake-raw/build.ps1 -OutFile build.ps1
```

* Next we are going to need a build.cake file
  * Create the file and add template

**demo1step1** - Basic Cake Template
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

**demo1step2** - NuGet Package Restore Step
  ```
    NuGetRestore("./Source/Gep13.Cake.Sample.WebApplication.sln");
  ```
