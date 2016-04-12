* `git checkout Demo3`
* Add task for running xUnit Tests

```
Task("Run-xUnit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    XUnit2("./Source/**/bin/" + configuration + "/*.xUnitTests.dll", new XUnit2Settings {
        OutputDirectory = "./.build/TestResults",
        XmlReportV1 = true,
        NoAppDomain = true
    });
});
```

* Change Dependency on Default Task to point at Run-xUnit-Tests Task
* Try to run the build, witness it fail
* Explain that there are two ways to add the missing tool
  * adding to existing package.config file, so that the bootstrapper will take care of adding the required tool
  * adding preprocessor directive which will add the missing tool
* We will do the latter

```
///////////////////////////////////////////////////////////////////////////////
// TOOLS
///////////////////////////////////////////////////////////////////////////////
#tool xunit.runner.console
```

* Try to run the build, witness it fail.  Man, we just can't catch a break!
* This was due to the output folder not existing, we need to create that as part of our build process
* Add a Clean Task

```
Task("Clean")
    .Does(() =>
{
    CleanDirectories(new[] { "./.build/TestResults"} );
});
```

* Change Dependency on Run-xUnit-Tests Task to include Clean Task
* Run the build
* Check the build output folder for the result