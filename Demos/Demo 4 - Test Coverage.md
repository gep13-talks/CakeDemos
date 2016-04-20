* `git checkout Demo4`
* Modify Existing Unit Test Task to include Coverage

```
Task("Run-xUnit-Tests")
    .IsDependentOn("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var settings = new OpenCoverSettings {
        ArgumentCustomization = args => args.Append("-mergeoutput")
    };

    OpenCover(tool => {
        tool.XUnit2("./Source/**/bin/" + configuration + "/*.xUnitTests.dll", new XUnit2Settings {
            OutputDirectory = "./.build/TestResults",
            XmlReportV1 = true,
            NoAppDomain = true
        });
    },
    new FilePath("./.build/Coverage/result.xml"),
    settings
        .WithFilter("+[*]* -[xunit.*]* -[*.NUnitTests]* -[*.MSTests]* -[*.xUnitTests]*")
    );
});
```
* Extend Clean Task to include new output folder

```
CleanDirectories(new[] { "./.build/TestResults", "./.build/Coverage" });
```

* Add ReportGenerator Task

```
Task("Run-ReportGenerator")
    .IsDependentOn("Test")
    .Does(() =>
{
    ReportGenerator("./.build/Coverage/result.xml", "./.build/Coverage");
});
```

* Change Default Task to take a dependency on Run-ReportGenerator

* Add Tools to top of file so that they are added to Tools folder

```
#tool OpenCover
#tool ReportGenerator
```

* Same thing for MSTest and NUnit

```
Task("Run-NUnit-Tests")
    .IsDependentOn("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var settings = new OpenCoverSettings {
        ArgumentCustomization = args => args.Append("-mergeoutput")
    };

    OpenCover(tool => {
        tool.NUnit3("./Source/**/bin/" + configuration + "/*.NUnitTests.dll", new NUnit3Settings {
        Work = "./.build/TestResults"
        });
    },
    new FilePath("./.build/Coverage/result.xml"),
    settings
        .WithFilter("+[*]* -[xunit.*]* -[*.NUnitTests]* -[*.MSTests]* -[*.xUnitTests]*")
    );
});
```

```
Task("Run-MSTest-Tests")
    .IsDependentOn("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var settings = new OpenCoverSettings {
        ArgumentCustomization = args => args.Append("-mergeoutput")
    };

    OpenCover(tool => {
        tool.MSTest("./Source/**/bin/" + configuration + "/*.MSTests.dll", new MSTestSettings {
        ArgumentCustomization = args => args.Append(string.Format("/resultsfile:{0}", "./.build/TestResults/MSTestResults.trx"))
        });
    },
    new FilePath("./.build/Coverage/result.xml"),
    settings
        .WithFilter("+[*]* -[xunit.*]* -[*.NUnitTests]* -[*.MSTests]* -[*.xUnitTests]*")
    );
});
```