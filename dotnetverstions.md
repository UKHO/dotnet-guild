# .NET Core Version Guidance

Guidance on .NET Core versions and support lifecycles. Microsoft's 'Modern Lifecycle Policy' will require a little more forward planning than Framework did.

Remember, no support means no security updates!

## TL;DR

### C# 8.0

Recommendation for UKHO .NET teams: Do not use any of the features outside of .NET Core 3.x and Standard 2.1+ projects.

### Existing applications

Upgrades required to stay in support:

- .NET Core 1.0 and 1.1 ended support 27 June 2019 and should now be on either 2.1 or 2.2.
- .NET Core 2.0 ended support 1 October 2018 and should now be on either 2.1 or 2.2.
- You have until 23 December 2019 to upgrade any 2.2 applications to 3.0 before you lose support.

There is no need, if you don't need any 3.0 features, to upgrade any .NET Framework applications - it is not going anywhere.

There is no pressing need to upgrade Core 2.1 apps. These are in support until at least August 2021.

### For new work

If you can resource an upgrade to 3.1 for Long-Term Support (LTS) between November 2019 and January 2020:

- Start all new work in Core 3.0
- Note, C# 8.0 will only be **supported** in Core 3.0 (and Standard 2.1) onwards

Otherwise:

- Use the current LTS release .NET Core 2.1 with LTS to August 2021

## Contacts

- Ben Hall @benhall_io

## The Long-Term Support Path

.NET Core 2.1 is the stable Long-Term Support (LTS) release, supported to around August 2021.

If an application is on 2.1, you do not need to upgrade to 3.0 until the LTS expires but if you do need 3.x features you probably want to wait for the next LTS release .NET 3.1, dropping around November 2019.

## The ‘Current’ Path

.NET Core 2.2 is a ‘Current’ release so to remain in support, 2.2 applications would need to be upgraded to 3.0 by around December 2019; and upgraded again, around February 2020 up to 3.1.

## Future of running Core on Framework

Note that ASP .NET Core 3.x is not going to run on Framework, so definitely do not upgrade anything to 2.2 that you wish to continue running on Framework.

There might be implications for Core applications currently running on Framework, when 2.1 goes out of support. Not sure yet - there is extended support for running ASP .NET Core 2.1 on Framework that would see ASP .NET Core 2.1 related packages being supported indefinitely. We'll have to wait and see; their intention is still for everyone to full migrate.

## When to upgrade 2.1 and 2.2 applications

Any planned work to upgrade existing 2.x applications to 3.x should be delayed until the LTS 3.1 release, given the short support period (to February 2020) that will accompany 3.0.

## Advice on using C# 8 features

C# 8.0 features are only officially supported in Core 3.0 (and Standard 2.1) onwards.

A number of them work fully or partially in .NET Framework and .NET Core 2.1 and 2.2 with some manual project tweaking.

I advising against using these features outside of .NET Core 3.0.
