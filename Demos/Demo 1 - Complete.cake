var target = Argument("target", "Default");

Task("NuGet-Package-Restore")
    .Does(() =>
{
    NuGetRestore("./Source/Gep13.Cake.Sample.WebApplication.sln");
});

Task("Default")
  .IsDependentOn("NuGet-Package-Restore");

RunTarget(target);