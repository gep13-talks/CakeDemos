* `git checkout Demo2`
* Add additional argument to top of file

```
var configuration = Argument("configuration", "Release");
```

* Add a task for running MSBuild

```
Task("Build")
    .IsDependentOn("NuGet-Package-Restore")
    .Does(() =>
{
    MSBuild("./Source/Gep13.Cake.Sample.WebApplication.sln", new MSBuildSettings()
        .SetConfiguration(configuration)
        .WithProperty("Windows", "True")
        .WithProperty("TreatWarningsAsErrors", "True")
        .UseToolVersion(MSBuildToolVersion.NET45)
        .SetVerbosity(Verbosity.Minimal)
        .SetNodeReuse(false));
});
```

* Change Dependency on Default Task to point at Build Task
