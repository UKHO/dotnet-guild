# .NET Core Version Guidance

Guidance on .NET Core versions and support lifecycles. Microsoft's 'Modern Lifecycle Policy' will require a little more forward planning than Framework did.

Remember, no support means no security updates!

## Existing applications

.NET Framework upgrades required to stay in support:

- .NET Framework support for 4, 4.5 and 4.5.1 ended in 2016 and you should be on 4.5.2 or greater, 2.0, 3.0 or 3.5 SP1. See the [.NET Framework Lifecycle FAQ for more details](https://support.microsoft.com/en-gb/help/17455/lifecycle-faq-net-framework).

There is no need, if you don't need any Core 3.x features, to upgrade any .NET Framework applications - it is not going anywhere. Microsoft still endeavour not to make breaking changes so it is safe to upgrade to the latest versions, which is 4.8.

.NET Core upgrades required to stay in support:

- .NET Core 1.0 and 1.1 ended support 27 June 2019 and should now be on either 2.1 or 3.1.
- .NET Core 2.0 ended support 1 October 2018 and should now be on either 2.1 or 3.1.

If you are on Core 2.2 and 3.1 is not an option because of dependencies, you might have to consider a downgrade.

There is no pressing need to upgrade Core 2.1 apps. These are in support until at least August 2021.

## For new work

 The Long-Term Support (LTS) release of .NET Core is 3.1.

- Supported in Azure App Service.
- Expected to be supported soon by our on-premise Azure DevOps build agents. Alternatively you can add it during build step in pipeline e.g.

```yaml
- task: UseDotNet@2
  displayName: 'Use .NET Core 3.1 SDK'
  inputs:
    packageType: sdk
    version: 3.1.x
    installationPath: $(Agent.ToolsDirectory)\\dotnet
```

## Future of running Core on the Framework

ASP .NET Core 3.x will not run on Framework. There might be implications for Core applications currently running on Framework, when 2.1 goes out of support. Not sure yet - there is extended support for running ASP .NET Core 2.1 on Framework that would see ASP .NET Core 2.1 related packages being supported indefinitely. We'll have to wait and see; their intention is still for everyone to fully migrate.

## C# 8

C# 8.0 features are only officially supported in Core 3.x (and Standard 2.1) onwards.

A number of them work fully or partially in .NET Framework and .NET Core 2.1 and 2.2 with some manual project tweaking but the recommendation for UKHO .NET teams is not to use any C# 8 features outside of .NET Core 3.x and Standard 2.1+ projects.

## Contacts

- Ben Hall @benhall_io
