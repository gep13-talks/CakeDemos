///////////////////////////////////////////////////////////////////////////////
// TOOLS
///////////////////////////////////////////////////////////////////////////////
#tool nuget:http://localhost:8081/repository/cake/?package=xunit.runner.console
#tool nuget:http://localhost:8081/repository/cake/?package=NUnit.ConsoleRunner

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("NuGet-Package-Restore")
    .Does(() =>
{
    NuGetRestore("./Source/Gep13.Cake.Sample.WebApplication.sln");
});

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

Task("Clean")
    .Does(() =>
{
    CleanDirectories(new[] { "./.build/TestResults" });
});

Task("Run-xUnit-Tests")
    .IsDependentOn("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    XUnit2("./Source/**/bin/" + configuration + "/*.xUnitTests.dll", new XUnit2Settings {
        OutputDirectory = "./.build/TestResults",
        XmlReportV1 = true,
        NoAppDomain = true
    });
});

Task("Default")
  .IsDependentOn("Run-xUnit-Tests");

RunTarget(target);