# Translations Helper mod

[Mod README](TranslationsHelper/README.md)

## Built with Jötunn inside

A Valheim mod stub project using [Jötunn](https://github.com/Valheim-Modding/Jotunn) including build tools and a basic Unity project stub. There is no actual plugin content included, just a bare minimum plugin class. 

A new environment file `Environment.props` can be created in the projects base path `<JotunnModStub>`.
Make sure you are not in any subfolder.
Paste this snippet and change the paths accordingly.
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- Valheim install folder. This is normally found automatically, uncomment to overwrite it. Needs to be your path to the base Valheim folder. -->
    <!-- <VALHEIM_INSTALL>X:\PathToYourSteamLibary\steamapps\common\Valheim</VALHEIM_INSTALL>-->

    <!-- This is the folder where your build gets copied to when using the post-build automations -->
    <MOD_DEPLOYPATH>$(VALHEIM_INSTALL)\BepInEx\plugins</MOD_DEPLOYPATH>
  </PropertyGroup>
</Project>
```
