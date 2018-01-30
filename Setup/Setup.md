* Clear out all changes in git for the CakeDemos repo
  * git reset --hard
  * git clean -xfd
  * delete BuildArtifacts folder
  * delete bin/obj folders
* Open VSCode pointing at the local GitHub Repo
* Start Nexus Docker Image
* Turn off notifications
* Turn off Wifi
* Open iTerm, navigate to repo folder, start python web server `python -m SimpleHTTPServer`
* Open local Web Site in order to show documentation screen
* Start Speaker Clock
* Put phone onto flight mode
* Install Cake VSCode extension
* Setup local VSCode configuration
```
    "cake.bootstrappers": {
        "powershell": "http://localhost:8081/repository/cake-raw/build.ps1",
        "bash": "http://localhost:8081/repository/cake-raw/build.sh"
    },
    "cake.configuration": {
        "config": "http://localhost:8081/repository/cake-raw/cake.config"
    },
```
