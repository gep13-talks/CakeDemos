# Cake Demos

Demo Repository for showing usage of the [Cake](http://cakebuild.net/) build automation and orchestration tool.

# Presentations

* This talk was first given at [Aberdeen Developers .Net User Group on Thursday 21st April 2016](http://www.aberdeendevelopers.co.uk/april-2016-meeting-gary-ewan-park/).  The slides for the talk can be found [here](http://www.slideshare.net/gep13/having-your-cake-and-eating-it-too).

**NOTE:** If you want to see the code and demos that were provided at this presentation, please ensure you use the [adnuguk tag](https://github.com/gep13/CakeDemos/releases/tag/adnuguk).

* It was then given at [DDD Scotland 2016](http://ddd.scot/) on 14th May 2016.  The slides for the talk can be found [here](http://www.slideshare.net/gep13/having-your-cake-and-eating-it-too-dddscotland).

**NOTE:** If you want to see the code and demos that were provided at this presentation, please ensure you use the [DDDScot2016 tag](https://github.com/gep13/CakeDemos/releases/tag/DDDScot2016).

* It was then given at [NDC Oslo](http://ndcoslo.com/) on 9th June 2016.  The slides for the talk can be found [here](http://www.slideshare.net/gep13/having-your-cake-and-eating-it-too-ndc-oslo-2016).

**NOTE:** If you want to see the code and demos that were provided at this presentation, please ensure you use the [NDCOslo2016 tag](https://github.com/gep13/CakeDemos/releases/tag/NDCOslo2016).

* It was then given at [DDD11](http://developerdeveloperdeveloper.com/) on 3rd September 2016.  The slides for the talk can be found [here](http://www.slideshare.net/gep13/a-piece-of-cake-ddd11-reading).

**NOTE:** If you want to see the code and demos that were provided at this presentation, please ensure you use the [DDD11 tag](https://github.com/gep13/CakeDemos/releases/tag/DDD11)

* It was then given at [DDD North](http://www.dddnorth.co.uk/) on 1st October 2016.  The slides for the talk can be found [here](http://www.slideshare.net/gep13/a-piece-of-cake-ddd-north).

**NOTE:** If you want to see the code and demos that were provided at this presentation, please ensure you use the [DDDNorth tag](https://github.com/gep13/CakeDemos/releases/tag/DDDNorth)

* It was then given at [KC .NET User Group](https://www.meetup.com/KC-NET-User-Group) on the 30th January 2018.  The slides for the talk can be found [here](https://gitpitch.com/gep13/CakeDemos/KCDUG#/).

**NOTE:** If you want to see the code and demos that were provided at this presentation, please ensure you use the [KCDUG branch](https://github.com/gep13/CakeDemos/tree/KCDUG).

* It was then given at [.Net Oxford](https://www.meetup.com/dotnetoxford) on the 6th February 2018.  The slides for the talk can be found [here](https://gitpitch.com/gep13/CakeDemos/dotnetoxford#/).

**NOTE:** If you want to see the code and demos that were provided at this presentation, please ensure you use the [dotnetoxford branch](https://github.com/gep13/CakeDemos/tree/dotnetoxford).

* It was then given at [London .NET User Group](https://www.meetup.com/London-NET-User-Group) on the 7th February 2018.  The slides for the talk can be found [here](https://gitpitch.com/gep13/CakeDemos/dotnetlondon#/).

**NOTE:** If you want to see the code and demos that were provided at this presentation, please ensure you use the [dotnetlondon branch](https://github.com/gep13/CakeDemos/tree/dotnetlondon).

* It was then given at [.Net Sheffield](https://www.meetup.com/dotnetsheff) on the 8th February 2018.  The slides for the talk can be found [here](https://gitpitch.com/gep13/CakeDemos/dotnetsheff#/).

**NOTE:** If you want to see the code and demos that were provided at this presentation, please ensure you use the [dotnetsheff branch](https://github.com/gep13/CakeDemos/tree/dotnetsheff).

# Running Demos with no external internet connection

In order to run this demo, the following infrastructure needs to be in place (this is due to the fact that the demo is designed to be run offline, with no external network connection).

* Install [Nexus OSS](https://chocolatey.org/packages/nexus-repository) `choco install nexus-repository`
* Set up two new repositories: http://localhost:8081/repository/cake/ which is a nuget feed, and http://localhost:8081/repository/cake-raw/ and is a raw feed
* Use the following configuration in user settings for VSCode
    "cake.bootstrappers": {
        "powershell": "http://localhost:8081/repository/cake-raw/build.ps1",
        "bash": "http://cakebuild.net/download/bootstrapper/bash"
    }
* Push the following resources into the cake-raw repository
  * curl.exe -v -u <username>:<password> --upload-file .\Resources\cake-raw\packages.config http://localhost:8081/repository/cake-raw/packages.config
  * curl.exe -v -u <username>:<password> --upload-file .\Resources\cake-raw\build.ps1 http://localhost:8081/repository/cake-raw/build.ps1
  * curl.exe -v -u <username>:<password> --upload-file .\Resources\cake-raw\build.ps1 http://localhost:8081/repository/cake-raw/build.sh
  * curl.exe -v -u <username>:<password> --upload-file .\Resources\cake-raw\NuGet.exe http://localhost:8081/repository/cake-raw/NuGet.exe
* Add the contentsof the .\Resources\snippets\csharp.json file to your C# snippets file in VSCode
* Push the following packages into the cake repository:
  * nuget push C:\users\gary.park\Downloads\Cake.0.25.0.nupkg -source http://localhost:8081/repository/cake/
  * Cake.Bakery
  * Cake.Common
  * Cake.Core
  * Cake.CoreCLR
  * Cake.Frosting
  * Cake.Frosting.Cli
  * Cake.NuGet
  * Cake.Testing
  * dapper

# Running Demos with external internet connection

If you don't want to use a local setup, you will need to made some minor modifications to this repository:

* delete the cake.config file, so that packages are restored from the internet, rather than local Nexus Repository.
* Remove the local VSCode configuration which specifies where to fetch NuGet Sources from.
* Add a packages.config file to the tools folder which contains the following:

```
<?xml version="1.0" encoding="utf-8"?>
<packages>
    <package id="Cake" version="0.25.0" />
    <package id="Cake.CoreCLR" version="0.25.0" />
</packages>
```

**NOTE:** If there is a newer version of Cake available, change the packages.config versions as necessary.  The addition of the Cake.CoreCLR package is to allow debugging within VSCode.  This is only possible in versions of Cake starting at 0.16.0.
