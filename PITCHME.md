@title[A Piece of Cake]

## A Piece of Cake
### C# powered cross platform build automationß

---

@title[Disclaimer]
## Disclaimer

+++

## Fit like i'day?

---

@title[What is a Build?]
## What is a Build?

Note:
Cake creates a Directed acyclic graph of each of the tasks.

Makes sure that each task is only run once.

+++

@title[Build Step]
Typical Build Workflow

<!-- .slide: data-background-transition="none" -->
![Build Step](assets/images/build-workflow-1.png)

+++

@title[Package Restore Step]
Typical Build Workflow

<!-- .slide: data-background-transition="none" -->
![Package Restore Step](assets/images/build-workflow-2.png)

+++

@title[Unit Test Step]
Typical Build Workflow

<!-- .slide: data-background-transition="none" -->
![Unit Test Step](assets/images/build-workflow-3.png)

+++

@title[Clean Step]
Typical Build Workflow

<!-- .slide: data-background-transition="none" -->
![Clean Step](assets/images/build-workflow-4.png)

+++

@title[Test Coverage Step]
Typical Build Workflow

<!-- .slide: data-background-transition="none" -->
![Test Coverage Step](assets/images/build-workflow-5.png)

+++

@title[Code Inspection Step]
Typical Build Workflow

<!-- .slide: data-background-transition="none" -->
![Code Inspection Step](assets/images/build-workflow-6.png)

+++

@title[Package Step]
Typical Build Workflow

<!-- .slide: data-background-transition="none" -->
![Package Step](assets/images/build-workflow-7.png)

+++

@title[Publish Step]
Typical Build Workflow

<!-- .slide: data-background-transition="none" -->
![Publish Step](assets/images/build-workflow-8.png)

---

## What is Cake?

Note:
Full disclosure, I am one of three maintainers of the Cake project on GitHub.

Some history/information:
- Open Source
- Supports the most common tools out of the box
- Cross Platform (Windows OS X Linux)
- Small but slowly growing
  - almost 900 Pull Requests 
  - 134 Contributors 
  - over 200 third party addins
  - 1575 Stars
  - Over 1.5 million downloads

+++

@title[Cake Logo]
![Cake Logo](assets/images/cake-logo.png)

+++

@title[A Definition...]
### A Definition...

"Cake (C# Make) is a cross platform build automation system with a C# DSL to do things like compiling code, copy files/folders, running unit tests, compress files and build NuGet packages.”

Note:
Built using Roslyn, allowing execution on both Windows, OS X and Linux.

Script Processing to make sure things work the same on both.

---

@title[How does Cake work?]
## How does Cake work?

+++

@title[Start with Cake.exe/dll]
![Start with Cake.exe or Cake.dll](assets/images/how-does-cake-work-1.png)

+++

@title[Available from lots of places]
<!-- .slide: data-background-transition="none" -->
![Available from lots of sources](assets/images/how-does-cake-work-2.png)

+++

@title[Add Configuration]
<!-- .slide: data-background-transition="none" -->
![Pass in arguments and configuration](assets/images/how-does-cake-work-3.png)

+++

@title[Pass your build script]
<!-- .slide: data-background-transition="none" -->
![Pass in your build script](assets/images/how-does-cake-work-4.png)

+++

@title[Add pre-processor directives]
<!-- .slide: data-background-transition="none" -->
![Use some pre-processor directives](assets/images/how-does-cake-work-5.png)

+++

@title[Compile with Roslyn]
<!-- .slide: data-background-transition="none" -->
![Roslyn used to compile your script](assets/images/how-does-cake-work-6.png)

+++

@title[Script will be executed]
<!-- .slide: data-background-transition="none" -->
![Script will be executed](assets/images/how-does-cake-work-7.png)

+++

@title[Tada!]
<!-- .slide: data-background-transition="none" -->
![Output can be anything you want](assets/images/how-does-cake-work-8.png)

---

@title[What tools am I able to use with Cake?]
## What tools am I able to use with Cake?

+++

@title[Lots of tools!]
![Cake Tools](assets/images/tools-you-can-use-with-cake.png)

Note:
Black ones are built in and ship with Cake.

Blue ones are those that have been created by the community.

There are aliases that span across:
  * Unit Testing Frameworks
  * Test Coverage
  * Static Code Analysis
  * JavaScript Runners
  * Documentation Generators
  * Chat Systems
  * Publishing

---

@title[Okay, but why do I need it?]
## Okay, but why do I need it?

![Why do I need Cake?](assets/images/but-why-do-i-need-it.png)

Note:
Talk about compiling directly out of Visual Studio:
  - You might run some Unit Tests after the build has completed
  - You might run some static analysis tools within Visual Studio
  - You might manually create and deploy a package once you know that everything works

This is prone to human error, and not repeatable or maintainable as the complication of the application increases

---

@title[We build Cake with Cake on...]
## We build Cake with Cake on...

![Build Cake with Cake](assets/images/build-cake-with-cake.png)

Note:
9 Different CI Servers.

3 Different Operating Systems.
---

@title[Can't I just use...]
## Can't I just use...

- FAKE
- MAKE |
- CMake |
- MSBuild |
- NAnt |
- PSake |
- Bau |
- ? |

Note:
You can use any of these that you want.

Fully agree with the concept of a polyglot developer, but from a strictly pragmatic point of view, writing a build script in the same language as you are developing, makes a lot of sense.

---

@title[Source Code]
## Source Code
### http://gep13.me/CakeDemos

---

@title[Let's bake some Cake]
## Let's bake some Cake
![What we will do in demo](assets/images/what-we-will-do-in-demo.png)

---

@title[Demos]
## Demos

Note:
Mention laptop setup:

* Working in offline mode
* All commands are still executed as they would be if doing it in reallife
* Only slightly modified bootstrapper and configuration file

---

@title[Questions]
## Questions?

Feel free to get in touch

Email: gep13@gep13.co.uk

Twitter: @gep13

Web: http://www.gep13.co.uk

---

@title[Resources]
## Resources

* Cake Documentation - https://cakebuild.net/docs/
* Source Code - https://github.com/cake-build/cake
* Presentations - https://cakebuild.net/docs/resources/presentations
* Podcasts - https://cakebuild.net/docs/resources/podcasts
* Videos - https://cakebuild.net/docs/resources/videos
* Blog Posts - https://cakebuild.net/docs/resources/blogs