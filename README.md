# veracode-packager
This tool is intended to help package application for Veracode scanning. It is a personal project and has no affiliation with Veracode.

Much of the implementation was inspired by https://github.com/nhinv11/veracode-dotnet-packager

In fact, this project only exists as I wanted to install and use the packager as a dotnet global tool.

# Building the tool
To build:

dotnet build .\Packager.sln -c Release

The primary application project is found in ./src/Packager

# Using the tool

## Publish the target application
The tool currently supports packaging .net core and .net 5+ applications. Applications must be published before they can be packaged. To publish, from the target application source directory run:

dotnet publish c Debug /p:UseAppHost=false /p:SatelliteResourceLanguages="en"

## Run the tool

veracode-package pack --help

```text
Description:
  Creates an archive including the required files for Veracode scanning

Usage:
  veracode-packager pack <target> [options]

Arguments:
  <target>  The directory containing the application

Options:
  -o, --output <output>                    The output file path [default: <string-sortable-date>-veracode-package.zip]
  -p, --platform <Dotnet|DotnetFramework>  The targeted application platform
  -?, -h, --help                           Show help and usage information
```

# Run as a dotnet global tool
Veracode Packager can be run as a standalone application or as a dotnet tool.

## Package

dotnet pack .\src\Packager\Packager.csproj -c Release -o .\nupkg\

## Install

dotnet tool install veracode-package --global --add-source .\nupkg\ --prerelease


# Contribute
Please do. Feel free to add features and fix bugs using a `Merge Request`.

# Bug

If you find a bug, please file an Issue GitHub, and fix it yourself with a `Merge Request` or wait for me to address as time allows.