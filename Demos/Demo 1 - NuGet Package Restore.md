# Demo 1 - NuGet Package Restore

* First of all we are going to need a bootstrapper.  Use VSCode Command to download the bootstrapper.

* Next we are going to need a build.cake file. Create the file and add template

  **demo1step1** - Basic Cake Template

* Save the file, and run the build.  Show the tools folder getting populated, Cake downloaded, etc.

* Add the content of the NuGet Package Restore Task

  **demo1step2** - NuGet Package Restore Step

* Show the packages folder getting populated
* Run the build again, to show that the packages aren't restored again
* Delete the packages folder, and show it getting replaced again