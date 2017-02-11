# Minimum .NET Core ASP.NET WebApi-example

## Features:

 * Working example with common commands like:
    * `dotnet test`
    * `dotnet run`
    * `dotnet restore`
 * WebApi
 * Multiple projects and solution-file
 * Built-in DI capabilities http://kristian.hellang.com/third-party-dependency-injection-in-asp-net-core/
 * Static files serving
 * A testing environment including:
    * Tools: Xunit, Xunit test runner, Moq and AspNet.TestHost
    * Example of: HttpClient-fake, async tests and integration tests
 * Benchmarking of Task.WhenAll a.s.o

## Planned

 * PowerShell for build automation and change detection across multiple projects similar to `Make`.

## Supports the following development tools

Tools | Platform
----- | --------
Project Rider EAP (1) | OSX 10.11
Visual Studio Code (1)  | OSX 10.11

Verified with latest version at:
- (1) - 2017-02-01

## Starting web server
Remember to restore dependencies before running.

    dotnet run

## Urls
1. http://localhost:5000/api/values
2. http://localhost:5000/api/values/1
3. http://localhost:5000/example.json
