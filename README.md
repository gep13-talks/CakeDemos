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
  * curl.exe -v -u <username>:<password> --upload-file .\Resources\cake-raw\NuGet.exe http://localhost:8081/repository/cake-raw/NuGet.exe
* Push the following packages into the cake repository:
  * nuget push C:\users\gary.park\Downloads\Cake.0.16.0-alpha0075.nupkg -source http://localhost:8081/repository/cake/
  * Antlr
  * bootstrap
  * Cake.Common
  * Cake.Core
  * Cake.CoreCLR
  * Cake.Frosting
  * Cake.Frosting.Cli
  * Cake.NuGet
  * Cake.Testing
  * EntityFramework
  * jQuery
  * jQuery.Validation
  * Microsoft.ApplicationInsights
  * Microsoft.ApplicationInsights.Agent.Intercept
  * Microsoft.ApplicationInsights.DependencyCollector
  * Microsoft.ApplicationInsights.JavaScript
  * Microsoft.ApplicationInsights.PerfCounterCollector
  * Microsoft.ApplicationInsights.Web
  * Microsoft.ApplicationInsights.WindowsServer
  * Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel
  * Microsoft.AspNet.Identity.Core
  * Microsoft.AspNet.Identity.EntityFramework
  * Microsoft.AspNet.Identity.Owin
  * Microsoft.AspNet.Mvc
  * Microsoft.AspNet.Razor
  * Microsoft.AspNet.Web.Optimization
  * Microsoft.AspNet.WebPages
  * Microsoft.CodeAnalysis.CSharp
  * Microsoft.CodeAnalysis.Scripting
  * Microsoft.CodeDom.Providers.DotNetCompilerPlatform
  * Microsoft.jQuery.Unobtrusive.Validation
  * Microsoft.Net.Compilers
  *	Microsoft.Owin
  *	Microsoft.Owin.Host.SystemWeb
  *	Microsoft.Owin.Security
  *	Microsoft.Owin.Security.Cookies
  *	Microsoft.Owin.Security.Facebook
  *	Microsoft.Owin.Security.Google
  *	Microsoft.Owin.Security.MicrosoftAccount
  *	Microsoft.Owin.Security.OAuth
  *	Microsoft.Owin.Security.Twitter
  * Microsoft.Web.infrastructure
  * Modernizr
  * Newtonsoft.Json
  * NUnit
  * NUnit.ConsoleRunner
  * OpenCover
  * Owin
  * ReportGenerator
  * Respond
  * Roslyn.Compilers.Common
  * Roslyn.Compilers.CSharp
  * WebGrease
  * xunit
  * xunit.abstractions
  * xunit.assert
  * xunit.core
  * xunit.extensibility.core
  * xunit.extensibility.execution
  * xunit.runner.console

# Running Demos with external internet connection

If you don't want to use a local setup, you will need to made some minor modifications to this repository:

* delete the cake.config file, so that packages are restored from the internet, rather than local Nexus Repository.
* Remove the local VSCode configuration which specifies where to fetch NuGet Sources from.
* Add a packages.config file to the tools folder which contains the following:

```
<?xml version="1.0" encoding="utf-8"?>
<packages>
	<package id="Cake" version="0.16.0" />
    <package id="Cake.CoreCLR" version="0.16.0" />
</packages>
```

**NOTE:** If there is a newer version of Cake available, change the packages.config versions as necessary.  The addition of the Cake.CoreCLR package is to allow debugging within VSCode.  This is only possible in versions of Cake starting at 0.16.0.
