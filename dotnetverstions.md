# .NET Core Version Guidance

Guidance on .NET Core versions and support lifecycles. Microsoft's 'Modern Lifecycle Policy' will require a little more forward planning than Framework did.

Remember, no support means no security updates!

## Existing applications

Upgrades required to stay in support:

- .NET Core 1.0 and 1.1 ended support 27 June 2019 and should now be on either 2.1 or 3.1.
- .NET Core 2.0 ended support 1 October 2018 and should now be on either 2.1 or 3.1.
- 2.2 applications go out of support 23 December 2019. Make sure you have upgraded to 3.1.

If you are on 2.2 and 3.1 is not an option  for dependency reasons you might have to consider a downgrade.

There is no need, if you don't need any 3.x features, to upgrade any .NET Framework applications - it is not going anywhere.

There is no pressing need to upgrade Core 2.1 apps. These are in support until at least August 2021.

## For new work

 The Long-Term Support (LTS) release of .NET Core is 3.1.

- Supported in Azure App Service.
- Expected to be supported shortly by our on premise Azure DevOps build agents.

## Future of running Core on Framework

ASP .NET Core 3.x will not run on Framework. There might be implications for Core applications currently running on Framework, when 2.1 goes out of support. Not sure yet - there is extended support for running ASP .NET Core 2.1 on Framework that would see ASP .NET Core 2.1 related packages being supported indefinitely. We'll have to wait and see; their intention is still for everyone to fully migrate.

## C# 8

C# 8.0 features are only officially supported in Core 3.x (and Standard 2.1) onwards.

A number of them work fully or partially in .NET Framework and .NET Core 2.1 and 2.2 with some manual project tweaking.

Recommendation for UKHO .NET teams: Do not use any of the features outside of .NET Core 3.x and Standard 2.1+ projects.

## Contacts

- Ben Hall @benhall_io
