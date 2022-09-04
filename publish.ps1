$pass = Read-Host -Prompt "Passphrase"
dotnet publish -f:net6.0-android -c:Release .\SolidAmslerGridWithColors\SolidAmslerGridWithColors.sln /p:AndroidSigningKeyPass=$pass /p:AndroidSigningStorePass=$pass
