var target = Argument("target", "Default");

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

Task("Default")
  .IsDependentOn("DotNet-Core-Package-Restore");

RunTarget(target);