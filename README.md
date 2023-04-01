# Calebs.Extensions
Useful extension methods and attributes for working with enums, strings and lists.

### Installing Calebs.Extensions

You should install [Extensions with NuGet](https://www.nuget.org/packages/Calebs.Extensions):

    Install-Package Calebs.Extensions
    
Or via the .NET Core command line interface:

    dotnet add package Calebs.Extensions

Either command, from Package Manager Console or .NET Core CLI, will download and install Calebs.Extensions and all required dependencies.

### .NET 7
These extensions target .NET 6 and .NET 7. With .NET 7 the `Calebs.Extensions.Validators` include `EnumStringValidator<T>`. The ability for Attributes to support <T> was added with .NET 7. 

# Extensions

## EnumExtensions
- ToList<D> - 
- ToList(Type)
- Description (enum)
- Description<ToDesc>(Enum)
- Parse<T>
- Parse <T, D>


## EnumStringValidator
Used for string properties in models that are supposed to conform to an enum value. 

## StringExtensions
- IsNotNullOrEmpty
- IsNullOrEmpty
- Compare

## ListExtensions
- ToDelimitedList
- ToUpper

## JsonExtensions
- ToJson<T>
- FromJson

## Versioning
This package follow semantic versioning as much as possible.

# Contributions
Please submit PR's to the `develop` branch. 
Merges to `deveoper` automtically run all unit tests and publish a nuget package with the postfix `-ci-build_number`
Merges to `main` publish to nuget as a major release. 

# Change Log
-
-
