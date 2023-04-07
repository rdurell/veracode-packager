cd VeracodePackager
npx tsc
cd ..
$fullSemVer = dotnet-gitversion | ConvertFrom-Json | Select-Object -ExpandProperty FullSemVer
$versionOverride = "{ `"version`" : `"$fullSemVer`" }"
tfx extension create --manifest-globs vss-extension.json --override "$versionOverride"
