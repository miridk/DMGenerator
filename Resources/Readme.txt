dotnet publish -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=false /p:SelfContained=false --output "C:\Users\PC\Desktop"


Single file release
dotnet publish -r win-x64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:SelfContained=true --self-contained --output "C:\temp\releaseParty"