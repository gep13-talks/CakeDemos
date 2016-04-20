* `git checkout Demo2`
* Add additional argument to top of file

**demo2step1** - Additional argument
```
var configuration = Argument("configuration", "Release");
```

* Add a task for running MSBuild

**demo2step2** - MSBuild Task

```
Task("Build")
    .IsDependentOn("NuGet-Package-Restore")
    .Does(() =>
{
    MSBuild("./Source/Gep13.Cake.Sample.WebApplication.sln", new MSBuildSettings()
        .SetConfiguration(configuration)
        .WithProperty("Windows", "True")
        .WithProperty("TreatWarningsAsErrors", "True")
        .UseToolVersion(MSBuildToolVersion.VS2015)
        .SetVerbosity(Verbosity.Minimal)
        .SetNodeReuse(false));
});
```

* Change Dependency on Default Task to point at Build Task

```
  .IsDependentOn("Build");
```