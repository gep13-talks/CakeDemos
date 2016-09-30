# Demo 5 - Debugging

## Visual Studio

* Add a `#break` directive in NuGetRestore Step
* Run the following command `cake build.cake --debug`
* Switch to Visual Studio, and attach to process id from previous step
* F10 through build script until at NuGet Pack Step
* Create Quick Watch on nugetPackSettings

## VSCode

* Set a breakpoint somewhere in the build.cake file
* Click F5
* F10 through build script until at NuGet Pack Step
* Hover over nugetPackSettings to see the contents