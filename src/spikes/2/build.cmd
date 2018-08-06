@echo off
msbuild Adrien.sln /p:Platform=x64 /p:Configuration=Debug %*
:end