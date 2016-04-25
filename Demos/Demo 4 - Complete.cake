///////////////////////////////////////////////////////////////////////////////
// TOOLS
///////////////////////////////////////////////////////////////////////////////
#tool nuget:http://localhost:8081/repository/cake/?package=xunit.runner.console
#tool nuget:http://localhost:8081/repository/cake/?package=NUnit.ConsoleRunner
#tool nuget:http://localhost:8081/repository/cake/?package=OpenCover
#tool nuget:http://localhost:8081/repository/cake/?package=ReportGenerator

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
    CleanDirectories(new[] { "./.build/TestResults", "./.build/nuget" });
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

Task("Package")
    .IsDependentOn("Run-xUnit-Tests")
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

Task("Default")
  .IsDependentOn("Package");

RunTarget(target);