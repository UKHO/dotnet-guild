# .NET Version Guidance <!-- omit in toc -->

## Table of contents  <!-- omit in toc -->

- [1. .NET Framework applications](#1-net-framework-applications)
  - [1.1. Out of support](#11-out-of-support)
  - [1.2. Currently supported](#12-currently-supported)
    - [1.2.1. Also still supported: .NET 3.5 SP1](#121-also-still-supported-net-35-sp1)
  - [1.3 Maintaining existing 4.x applications](#13-maintaining-existing-4x-applications)
    - [1.3.1 Upgrade the runtime (CLR)](#131-upgrade-the-runtime-clr)
    - [1.3.2 Re-targeting to the latest 4.x also](#132-re-targeting-to-the-latest-4x-also)
    - [1.3.4 Migrating from  .NET Framework (NETFx) to .NET vNext](#134-migrating-from--net-framework-netfx-to-net-vnext)
  - [1.4. Summary of recommendations for .NET Framework (NETFx) applications](#14-summary-of-recommendations-for-net-framework-netfx-applications)
- [2. Existing .NET Core Applications](#2-existing-net-core-applications)
  - [2.1 Currently supported .NET 5+ or .NET Core versions](#21-currently-supported-net-5-or-net-core-versions)
  - [2.2 Core versions out of support](#22-core-versions-out-of-support)
  - [2.3 .NET vNext](#23-net-vnext)
  - [2.4 Keeping Core patched with servicing updates](#24-keeping-core-patched-with-servicing-updates)
  - [2.5. Summary of recommendations for .NET Core applications](#25-summary-of-recommendations-for-net-core-applications)
- [3. For new work](#3-for-new-work)
- [4. Shared code libraries](#4-shared-code-libraries)
  - [What to target for a mix of NETFx, Core 3.1 and .NET 5+](#what-to-target-for-a-mix-of-netfx-core-31-and-net-5)
  - [What to target for a mix of .NET Core 3.1 / .NET 5+](#what-to-target-for-a-mix-of-net-core-31--net-5)
- [5. Future of running Core on the Framework](#5-future-of-running-core-on-the-framework)
- [6. C# versions](#6-c-versions)

## 1. .NET Framework applications

The current version is 4.8 and no further major versions will be released.

It will continue to receive updates for reliability, bugs or security fixes for as long as there is a Windows operating system.

### 1.1. Out of support

4, 4.5 and 4.5.1 (ended January 12, 2016)

### 1.2. Currently supported

All versions from 4.5.2 up to the the most recent release, 4.8, are supported.

There is a change of support for .NET Framework 4.5.2, 4.6, and 4.6.1, which will now end on April 26, 2022. This change is due to the [retirement of SHA-1](https://devblogs.microsoft.com/dotnet/net-framework-4-5-2-4-6-4-6-1-will-reach-end-of-support-on-april-26-2022).

.NET 4.8 will be supported until at least 01/09/2029 (the end of Windows 10 / Server 2019).

#### 1.2.1. Also still supported: .NET 3.5 SP1

- Support ends 01/09/2029.
- Lifecycle no longer tied to Windows.
- Still supported by Windows 10 / Server 2016.
- Due to the way it was built, it requires 2.0 SP2 and 3.0 SP2 so these will remain in support where 3.5 SP1 is installed.

### 1.3 Maintaining existing 4.x applications

As the bare minimum, ensure that the .NET Framework security updates are being applied via Windows Update.

Plan upgrades to the latest 4.x.x in good time and know your end-of-support dates. **Support for .NET Framework 4.5.2, 4.6, and 4.6.1 will end on April 26, 2022**.

Check the impact of migrating i.e. breaking changes, with the [tool available here](https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/application-compatibility#retargeting-changes).

Naturally, the risks associated with upgrading increase the longer it is delayed. Identify and fix problems early by keeping the runtime updated to the latest 4.x **and** ideally, re-targeting, rebuilding and redeploying also.

#### 1.3.1 Upgrade the runtime (CLR)

Upgrading the .NET version on a machine to the latest 4.x is low-risk but do run regression tests before going live. How much testing it takes to gain confidence, and the chances of breaking changes, depends largely on what version currently targeted.

The likelihood of experiencing problems running an existing 4.x app on the latest 4.x without re-targeting is lesser because:

> the .NET Framework uses quirked behavior to mimic the older targeted version. The app runs on the newer version but acts as if it's running on the older version. Many of the compatibility issues between versions of the .NET Framework are mitigated through this quirking model.

Assuming your application is already targeting a supported version of .NET (currently >= 4.5.2), then re-targeting to 4.8 ot later is not compulsory. Particularly if you do not plan to take advantage of any new features.

Advice is going to be different between server hosting that we manage and client software installed by the user.

#### 1.3.2 Re-targeting to the latest 4.x also

To re-target, rebuild and redeploy the application - this means actually using the latest framework from the code (not just running on it) while adopting new features and changes to the behaviour of features you already use.

A lot of unexpected behaviour from using the new runtime can be caught earlier by the compiler by re-targeting. Note that there are sometimes framework changes that require code changes and again, the likelihood depends on current target To get an idea of what work is needed:

- Details of breaking changes between versions, up to and include 4.8, are OSS and [indexed in the .NET docs on GitHub](https://github.com/Microsoft/dotnet/blob/master/Documentation/compatibility/README.md).
- Broader documentation around migrations are [detailed here](https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/).

#### 1.3.4 Migrating from  .NET Framework (NETFx) to .NET vNext

The decision whether or not to migrate to .NET Core or .NET 6 from .NET 4.x should be made on a case-by-case basis. The most important thing is to have a road-map for every application, particularly those which are mission-critical. The following summary can be used to assist in decision making.

Benefits of migrating:

- Developer engagement and attitudes to *legacy* code bases (if they have no access to other work with modern technologies). The C# language features are now tied to the framework version i.e. developers cannot use C# 8 unless they are targeting .NET Core 3.1 or later.
- New features and performance improvements (if either has been raised as a requirement).
- Dependencies will not support 4.x forever. Best guess is between 3 to 4 years (2023-2024) before third-party NETFx library support starts becoming problematic.

But that last point really is a guess. **The official line from Microsoft is still: Not to upgrade NETFx applications that are in 'maintenance mode'.** If this advice results in large numbers of applications remaining on NETFx, then third party support is likely to continue also.

Arguments against migrating off NETFx:

- 4.8 is in support until at least 01/09/2029.
- Application's own lifecycle may come to an end sooner than a migration to .NET vNext becomes essential.
- Dependencies still tied to 4.x.
  
There is a more compelling argument to migrate to Core 3.1 as an LTS product to 03/12/2022, instead of .NET 5. The first LTS for the new unified .NET is version 6, which is not planned for release until November 2021. The upgrade path from Core 3.1 to .NET 6 is likely to be straightforward.

Consider options of breaking systems up and migrating smaller parts.

### 1.4. Summary of recommendations for .NET Framework (NETFx) applications

If the application is likely to expire or move into maintenance-only mode before 2023 (thus there there are no requirements for the features or performance offered by Core and .NET vNext), then remain on the .NET Framework and upgrade to the latest 4.x. Re-targeting as well as a runtime upgrade, will ensure the application can use more shared code and be in a good position to migrate if circumstances change.

If an application's own lifecycle comfortably extends into 2024 with new features in the pipeline, then plan a migration away from NETfx. As of November 2021, this should be directly to .NET 6, which will be support until November 2024.

Make use of the migration guides e.g. [for ASP.NET](https://docs.microsoft.com/en-us/aspnet/core/migration/50-to-60?view=aspnetcore-3.1&tabs=visual-studio).

## 2. Existing .NET Core Applications

The road-maps for applications targeting .NET Core 3.1 or .NET 5 will be the similar. Both should have planned upgrades to .NET 6 but within different time windows depending on when their support expires.

### 2.1 Currently supported .NET 5+ or .NET Core versions

- .NET Core 3.1 is supported until 03/12/2022.
- .NET 5 is supported until around May 2022.

For more details and to check latest patch version see the [.NET Core and .NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

### 2.2 Core versions out of support

All other .NET Core 2.x and 3.x versions are out of support.

### 2.3 .NET vNext

.NET 7 is a 'Current' release, dropping around November 2022. It is likely to go out of support around January 2023.

### 2.4 Keeping Core patched with servicing updates

Self-contained: One of the benefits of Core (and .NET 5+) is the ability to have side-by-side installations of runtime versions. As of Core 3.x it is also possible to distribute self-contained executables that include the required Core runtime. The negative to both of these it that it remains a development team responsibility to ensure runtime updates occur.

Azure App Service: These will be patched automatically.

Core installed centrally on a machine: .NET Core and .NET 5 servicing updates can now be installed automatically on Windows, through Microsoft Update [see this post](https://failingfast.io/dotnet-core-automatic-windows-updates/).

### 2.5. Summary of recommendations for .NET Core applications

A road-map for remaining on LTS:

1. Core 3.1 -> .NET 6 (upgrade window November 2021 to 03/12/2022)
2. .NET 5 -> .NET 6 (upgrade window November 2021 to May 2022)
3. .NET 6 -> .NET 8 (upgrade window November 2023 to November 2025)

A road-map for jumping on and off the 'current train' (includes non-LTS releases):

1. Core 3.1 -> .NET 6 (upgrade window November 2021 to 03/12/2022)
2. .NET 5 -> .NET 6 (upgrade window November 2021 to May 2022)
3. .NET 6 -> .NET 7 (.NET 7 is non-LTS 'Current', released November 2022)
4. .NET 7 -> .NET 8 (upgrade window November 2022 to May 2024)

## 3. For new work

Use the Long-Term Support (LTS) release .NET 6, released November 2021.

## 4. Shared code libraries

These will be utilised increasingly to break systems up for migration.

In the long-term, expect most libraries internally, and those on NuGet, to multi-target .NET Standard 2.0 and .NET 5+.

### What to target for a mix of NETFx, Core 3.1 and .NET 5+

Many road-maps will upgrade parts of a system from NETFx, leaving some behind temporarily or permanently.

Target .NET Standard 2.0 and ensure lowest target is .NET 4.7.2.

Plan to add .NET 5+ support later if and when the latest platform features are needed.

### What to target for a mix of .NET Core 3.1 / .NET 5+

Targeting .NET Standard 2.1 (the final version) will make the library usable by both. To actually utilise new .NET 5+ features, consider multi-targeting Standard 2.1 and Core .NET 5+.

## 5. Future of running Core on the Framework

ASP .NET Core 3.x and greater will not run on Framework.

There is extended support for running ASP .NET Core 2.1 on Framework that would see ASP .NET Core 2.1 related packages being supported indefinitely. This is offered via support for particular packages, which are [listed here](https://dotnet.microsoft.com/platform/support/policy/aspnetcore-2.1). Note that packages must be kept up-to-date - only the latest patch versions are supported.

See full [ASP.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/aspnet).

This shouldn't be seen as a permanent solution - plan a migration onto the .NET Core / .NET 5+ runtime.

## 6. C# versions

C# 8.0 features are only officially supported in Core 3.x (and Standard 2.1) onwards.

C# 9.0 features are only officially supported in .NET 5 onwards.

C# 10.0 features are only officially supported in .NET 6 onwards.
