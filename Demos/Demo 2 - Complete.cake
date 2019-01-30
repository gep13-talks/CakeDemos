var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("DotNet-Core-Package-Restore")
    .Does(() =>
{
    DotNetCoreRestore(
        "./Source/Gep13.Cake.Sample.WebApplication",
        new DotNetCoreRestoreSettings {
            PackagesDirectory = "./Source/packages"
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

Task("Default")
  .IsDependentOn("Build");

RunTarget(target);
