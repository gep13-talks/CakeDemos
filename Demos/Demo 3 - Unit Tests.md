* `git checkout Demo3`
* Add task for running xUnit Tests

**demo3step1** - XUnit Task
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

**demo3step2** - XUnit Tool Resolution
```
///////////////////////////////////////////////////////////////////////////////
// TOOLS
///////////////////////////////////////////////////////////////////////////////
#tool nuget:http://localhost:8081/repository/cake/?package=xunit.runner.console
```

* Try to run the build, witness it fail.  Man, we just can't catch a break!
* This was due to the output folder not existing, we need to create that as part of our build process
* Add a Clean Task

**demo3step3** - Clean Task
```
Task("Clean")
    .Does(() =>
{
    CleanDirectories(new[] { "./.build/TestResults" });
});
```

* Change Dependency on Run-xUnit-Tests Task to include Clean Task

```
    .IsDependentOn("Clean")
```

* Run the build
* Check the build output folder for the result

* Then it is the same thing for NUnit and MSTest

**demo3step4** - NUnit Task
```
Task("Run-NUnit-Tests")
    .IsDependentOn("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NUnit3("./Source/**/bin/" + configuration + "/*.NUnitTests.dll", new NUnit3Settings {
        Work = "./.build/TestResults"
    });
});
```

**demo3step5** - NUnit Tool Resolution
```
///////////////////////////////////////////////////////////////////////////////
// TOOLS
///////////////////////////////////////////////////////////////////////////////
#tool nuget:http://localhost:8081/repository/cake/?package=NUnit.ConsoleRunner
```

**demo3step6** - MSTest Task
```
Task("Run-MSTest-Tests")
    .IsDependentOn("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    MSTest("./Source/**/bin/" + configuration + "/*.MSTests.dll", new MSTestSettings {
        ArgumentCustomization = args => args.Append(string.Format("/resultsfile:{0}", "./.build/TestResults/MSTestResults.trx"))
    });
});
```

**demo3step7** - Top level Test Task
```
Task("Test")
    .IsDependentOn("Run-xUnit-Tests")
    .IsDependentOn("Run-NUnit-Tests")
    .IsDependentOn("Run-MSTest-Tests");
```

* Update the default task to take a dependency on the new top level Test Task

```
Task("Default")
  .IsDependentOn("Test");
```