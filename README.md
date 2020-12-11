# Advent of Code 2020

An attempt to solve all 25 [Advent of Code 2020](https://adventofcode.com/) puzzles in C#, because where's the fun in doing Advent of Code in a programming language you already know?

This code was built and run using the following tools:

* Visual Studio Code: https://code.visualstudio.com/
* .NET 5.0 SDK: https://dotnet.microsoft.com/download/dotnet/5.0

## Commands used to create the projects

```
dotnet new console -o CLI
dotnet sln add CLI/CLI.csproj
dotnet new classlib -o AdventOfCode
dotnet sln add AdventOfCode/AdventOfCode.csproj
dotnet new xunit -o AdventOfCode.Test
dotnet sln add AdventOfCode.Test/AdventOfCode.Test.csproj
cd CLI
dotnet add reference ../AdventOfCode/AdventOfCode.csproj
cd ../AdventOfCode.Test
dotnet add reference ../AdventOfCode/AdventOfCode.csproj
cd ..
```

### Testing

```
dotnet test; stty echo
```

### Running

```
dotnet run -p CLI 1
```
