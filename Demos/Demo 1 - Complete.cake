var target = Argument("target", "Default");

Task("NuGet-Package-Restore")
    .Does(() =>
{
    NuGetRestore(
        "./Source/Gep13.Cake.Sample.WebApplication.sln",
        new NuGetRestoreSettings { 
            Source = new List<string>() { "http://localhost:8081/repository/cake/" }
        }
    );
});

Task("Default")
  .IsDependentOn("NuGet-Package-Restore");

RunTarget(target);