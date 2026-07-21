@echo off
setlocal

set /p VERSION=Type version: 
set /p PLATFORM=Type platform (win-x64/linux-x64/linux-arm64): 

if "%VERSION%"=="" (
    echo Version hasn't been typed
    pause
    exit /b 1
)

if "%PLATFORM%"=="" (
    echo Platform hasn't been typed
    pause
    exit /b 1
)

dotnet publish ".\API\Presentation\Presentation.csproj" ^
-c Release ^
-r %PLATFORM% ^
--self-contained ^
-o ".\Publish\API\v%VERSION%\%PLATFORM%"

if errorlevel 1 (
    echo Publish error
    pause
    exit /b 1
)

echo Version %VERSION% for %PLATFORM% published
pause