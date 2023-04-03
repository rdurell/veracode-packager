# VeracodePackager
VeracodePacakger outputs a zip archine containing the necessary files for a Veracode SCA scan.

## YAML example
```yaml

- task: veracodepackager@0
  displayName: VeracodePackager
  inputs:
    target: '$(Build.Repository.LocalPath)/src/App/bin/Release/net6.0/publish' # REQUIRED # 
    ouput: '$(Build.Repository.LocalPath)/veracode/app.scan.zip' # REQUIRED # The full path and filename for the output archive.
    platform: 'Dotnet' # The targeted application platform. Valid values are: Dotnet, DotnetFramework
```
