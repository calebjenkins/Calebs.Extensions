[![.github/workflows/dev-ci.yml](https://github.com/calebjenkins/Calebs.Extensions/actions/workflows/dev-ci.yml/badge.svg?branch=develop)](https://github.com/calebjenkins/Calebs.Extensions/actions/workflows/dev-ci.yml)
[![.github/workflows/main-publish.yml](https://github.com/calebjenkins/Calebs.Extensions/actions/workflows/main-publish.yml/badge.svg?branch=main)](https://github.com/calebjenkins/Calebs.Extensions/actions/workflows/main-publish.yml)
[![NuGet](https://img.shields.io/nuget/dt/calebs.extensions.svg)](https://www.nuget.org/packages/calebs.extensions) 
[![NuGet](https://img.shields.io/nuget/vpre/calebs.extensions.svg)](https://www.nuget.org/packages/calebs.extensions)

# Calebs.Extensions
Useful extension methods and attributes for working with enums, strings and lists. The majority of these extensions were born out of working with various models while building micro services. 

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
Used for string properties in models that are supposed to conform to an enum value. The philosophy of my micro-services have been to be liberal in what you accept and conservative in what you send.

`Let's propose a scenario:` - you are recieving a message (model) that represents an `account` with a field `accountType`. Now, in this scenarios `accountType` could be `Standard, Silver or Gold` values. The easy way to restrict this is with en enum. The problem is - that if the incoming message doesn't exactly have one of those values (say `"AccountStatus":"Gold-Status"` is passed in instead of `"AccountStatus":"Gold"`), and if you are leveraging `Microsoft Web API` with model binding - then it is likely that model binding will fail and you will return a `400 - Bad Request` by default. This is the correct response, but you might want to log what was actually sent, or add additional context like an error message stating what field or fields were incorrect and what values are supported for that field. This makes for a much more developer friendly API. 

So instead of having your model directly bind to an enum - and throw a Bad Request exception - you can accept a `string` in that field, and use the `Calebs.Extensions.Validators.EnumStringValidatorAttribute` to perform model validation and then decide how to handle the errors. 

## StringExtensions
- IsNotNullOrEmpty
- IsNullOrEmpty
- Compare

## ListExtensions
- ToDelimitedList 
- ToUpper

## JsonExtensions
For both of these extension methods I'm using the `Newtonsoft.Json` library. I'm planning on migrating to `System.Text.Json` as soon as it is viable. Right now, Newtonsoft is easeir to serialize enums to thier ToString() value rather than index, and to deserialize the same. For example, by default - an enum is serialized to the index of the value. So an enum with (High, Med, Low) values would otherwise be serialiezed to a 2, instead of to "Med". Serializing to "Med" is my prefered behavior. I will continue to evailuate `System.Text.Json` against these unit tests and most likely migrate at some point.
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
