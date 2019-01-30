var target = Argument("target", "Default");

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

Task("Default")
  .IsDependentOn("DotNet-Core-Package-Restore");

RunTarget(target);
