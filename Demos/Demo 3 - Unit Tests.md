Demo 3 - Unit Tests

* `git checkout Demo3`
* Add task for running xUnit Tests

  **demo3step1** - XUnit Task

* Change Dependency on Default Task to point at Run-xUnit-Tests Task
* Try to run the build, witness it fail
* Explain that there are two ways to add the missing tool
  * adding to existing package.config file, so that the bootstrapper will take care of adding the required tool
  * adding preprocessor directive which will add the missing tool
* We will do the latter

  **demo3step2** - XUnit Tool Resolution

* Try to run the build, witness it fail.  Man, we just can't catch a break!
* This was due to the output folder not existing, we need to create that as part of our build process
* Add a Clean Task

  **demo3step3** - Clean Task

* Change Dependency on Run-xUnit-Tests Task to include Clean Task

* Run the build
* Check the build output folder for the result

* Then it is the same thing for NUnit and MSTest

  **demo3step4** - NUnit Task

  **demo3step5** - NUnit Tool Resolution

  **demo3step6** - MSTest Task

  **demo3step7** - Top level Test Task

* Update the default task to take a dependency on the new top level Test Task