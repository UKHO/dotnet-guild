# Wrapping Calls to C# Configuration with the Options Pattern

*Note that this inspired by Microsoft's concept of a pattern, coming from the [framework developed for ASP .NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.1). There's no connection to the functional programming option type.*

This guide covers the rationale for the options pattern. It also provides examples for:

- A custom implementation for .NET full framework applications
- Implementing it with the ASP .NET Core options framework

## Contacts

- Ben Hall
- Rob David

## Benefits

**Fewer string literals**: No repeating of string literals (keys) throughout code, which aids refactoring tools and reduces typing errors.

**Type-safety**: A single location to parse string values to strongly-typed properties (the single benefit of using schema languages to enforce type-safety would not give good ROI).

**Default values**: A single location to return default values when required.

**Validation of values**: A single location to catch missing config entries, misspelled keys or invalid values/types. Sometimes config errors are only reproducible in the environment in which they occur.

**Fail-fast**: Straightforward to read and verify all values at application startup.

**Decoupled**: Code is decoupled from config file markup type.

**Grouped configs**: Group config classes into related settings in order to adhere to **Interface Segregation Principle** and **Separation of Concerns** - that application classes only depend on settings that they use and these settings are decoupled between parts of the applications.

**Nested configs**: Organise config classes via nesting.

**Unit testing**: No need to mirror app.config in the tests project or employ other magic. You can now mock calls to config easily.

## Example code

- [Jump to ASP .NET Core 2.1 example](docs/netcore21.md)
- [Jump to Full Framework example](docs/netfx.md)
- [Jump to .NET Core 2.1 Generic Host service example](docs/netcore21generichost.md)
