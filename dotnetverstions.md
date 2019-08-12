# .NET Core Version Guidance

Guidance on .NET Core versions and support lifecycles. Microsoft's 'Modern Lifecycle Policy' will require a little more forward planning than Framework did.

Remember, no support means no security updates!

## TL;DR

You should no longer be using:

- .NET Core 1.0 and 1.1 ended support 27 June 2019 and should now be on either 2.1 or 2.2.
- .NET Core 2.0 ended support 1 October 2018 and should now be on either 2.1 or 2.2.

Currently recommended for new work:

- The current Long-Term Support (LTS) release .NET Core 2.1.

Recommended for new work from ~ November 2019:

- Core 3.1 will be the next LTS, dropping around November 2019
- **Note: C# 8.0 will only be supported in Core 3.0 (and Standard 2.1) onwards**

## Contacts

- Ben Hall @benhall_io

## The Long-Term Support Path

.NET Core 2.1 is the stable Long-Term Support (LTS) release, supported to around August 2021.

Currently recommended for all new projects, particularly applications that won't be updated often. .NET 3.1 will be the next LTS release, dropping around November 2019, with 2.1 support cover until August 2021 to upgrade.

Expect to move to Core 3.1 with C# 8.0 as the default for new work from November 2019 where there are not dependencies.

Although it is disappointing not being able to adopt C# 8.0 at its release in September 2019, it would be prudent to develop for Core 2.1 but design with a 3.x upgrade in mind and wait to do so until LTS 3.1 drops (currently pencilled in for November 2019). This gives the framework time to stablise; and for Azure DevOps, Azure Cloud, developer tooling and third-party libraries to catch up.

## The ‘Current’ Path

.NET Core 2.2 is a ‘Current’ release. Based on known dates from Microsoft, to remain in support, 2.2 applications would need to be upgraded to 3.0 by around December 2019, 3 months after release; and again, around February 2020 up to 3.1.

As of .NET Core 3.0 Preview 7, Core 3.0 'is supported by Microsoft and can be used in production'. I also have further [confirmation](https://github.com/dotnet/corefx/issues/40039) that C# 8.0 will only be supported in Standard 2.1 and of course .NET Core 3.0.

If you start using 3.0 Preview 7, you must still plan to upgrade to 3.0 GA and then again to 3.1 over a relatively short period. Only use this if you can resource this manual update cadence that follows.

Not enough information on support in Azure DevOps, Azure Cloud, developer tooling and third party libraries. Currently have to develop in VS 2019 Preview 7 (or higher).

Given the restricted availability C# 8.0, we cannot not flatly rule out adopting 3.0 for new work from Preview 7 onwards in the exceptional case, where we know that code will not be in production until 3.0 GA has had enough time to drop (currently pencilled in for September 2019). Although do not expect it to be stable until 3.1.

## Future of running Core on Framework

Note that ASP .NET Core 3.x is not going to run on Framework, so definitely do not upgrade anything to 2.2 that you wish to continue running on Framework.

There might be implications for our Core applications currently running on Framework, when 2.1 goes out of support. Not sure yet - there is extended support for running ASP .NET Core 2.1 on Framework that would see ASP .NET Core 2.1 related packages being supported indefinitely. We'll have to wait and see; their intention is still for everyone to full migrate.

## When to upgrade 2.1 and 2.2 applications

Any planned work to upgrade existing 2.x applications to 3.x should be delayed until the LTS 3.1 release, given the short support period (to February 2020) that will accompany 3.0.
