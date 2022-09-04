$pass = Read-Host -Prompt "Passphrase"
dotnet publish --framework net6.0-android --configuration Release .\SolidAmslerGridWithColors\SolidAmslerGridWithColors.csproj /p:AndroidSigningKeyPass=$pass /p:AndroidSigningStorePass=$pass
