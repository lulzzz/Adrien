@echo off
dotnet build Adrien.sln /p:Platform=x64 /p:Configuration=Debug %*
:end