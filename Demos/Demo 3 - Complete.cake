var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("DotNet-Core-Package-Restore")
    .Does(() =>
{
    DotNetCoreRestore(
        "./Source/Gep13.Cake.Sample.WebApplication",
        new DotNetCoreRestoreSettings {
            Sources = new[] { "http://localhost:8081/repository/cake/" }
        }
    );
});

Task("Build")
    .IsDependentOn("DotNet-Core-Package-Restore")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings {
        Configuration = configuration,
        NoRestore = true
    };

    DotNetCoreBuild("./Source/Gep13.Cake.Sample.WebApplication/Gep13.Cake.Sample.WebApplication.csproj", settings);
});

Task("Publish")
    .IsDependentOn("Build")
    .Does(() => 
{
    var settings = new DotNetCorePublishSettings {
       Configuration = configuration,
       OutputDirectory = "./BuildArtifacts/"
    };

    DotNetCorePublish("./Source/Gep13.Cake.Sample.WebApplication/Gep13.Cake.Sample.WebApplication.csproj", settings); 
});

Task("Default")
  .IsDependentOn("Publish");

RunTarget(target);