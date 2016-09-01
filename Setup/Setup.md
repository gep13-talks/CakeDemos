* Clear out all changes in git for the CakeDemos repo
  * git reset --hard
  * git clean -xfd
  * delete BuildArtifacts folder
  * delete bin/obj folders
* Open Visual Studio and load the Demo Solution
* Rename nuget.exe that lives in here `C:\ProgramData\chocolatey\lib\NuGet.CommandLine\tools`
* Open Administrator Visual Studio but don't load solution
* Open VSCode pointing at the local GitHub Repo
* Start Nexus Server
* Open Picture Viewer with Demo progress
* Open markdown files on Surface for Demos
* Turn off notifications
* Turn off Wifi
* Open zoomit
* Open PowerPoint slidedeck
* Open local Web Site in order to show documentation screen
* Start Speaker Clock
* Install Cake VSCode extension
* Install Cake Visual Studio extension
* Setup local VSCode configuration
```
    "editor.renderWhitespace": true,
    "files.trimTrailingWhitespace": true,
    "terminal.integrated.shell.windows": "\\windows\\system32\\WindowsPowerShell\\v1.0\\powershell.exe",
    "cake.bootstrappers": {
        "powershell": "http://localhost:8081/repository/cake-raw/build.ps1",
        "bash": "http://cakebuild.net/download/bootstrapper/bash"
    }
```