* `git checkout Demo5`
* Add new task for NuGetPack

```
Task("Package")
    .IsDependentOn("Run-ReportGenerator")
    .Does(() =>
{
    var nuGetPackSettings   = new NuGetPackSettings {
        Id                      = "Gep13.Cake.Sample.Common",
        Version                 = "0.1.0",
        Title                   = "Common Library used by Gep13.Cake.Sample Web Application",
        Authors                 = new[] {"gep13"},
        Owners                  = new[] {"gep13"},
        Description             = "The best Common Library you have ever seen",
        ProjectUrl              = new Uri("https://github.com/gep13/CakeDemos"),
        IconUrl                 = new Uri("https://raw.githubusercontent.com/cake-build/graphics/master/png/cake-small.png"),
        LicenseUrl              = new Uri("https://github.com/gep13/CakeDemos/blob/master/LICENSE"),
        Copyright               = "gep13 2016",
        ReleaseNotes            = new [] {"Bug fixes", "Issue fixes", "Typos"},
        Tags                    = new [] {"Gep13", "Cake", "Sample"},
        RequireLicenseAcceptance= false,
        Symbols                 = false,
        NoPackageAnalysis       = true,
        Files                   = new [] {
            new NuSpecContent {Source = "Gep13.Cake.Sample.Common.dll", Target = "bin"},
        },
        BasePath                = "./Source/Gep13.Cake.Sample.Common/bin/" + configuration,
        OutputDirectory         = "./.build/nuget"
    };

    NuGetPack(nuGetPackSettings);
});
```

* Change Default Task dependency to point at Package

```
  .IsDependentOn("Package");
```

* Extend Clean task to include new nuget output folder

```
Task("Clean")
    .Does(() =>
{
    CleanDirectories(new[] { "./.build/TestResults", "./.build/Coverage", "./.build/nuget" });
});
```