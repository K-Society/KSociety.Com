@call "C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\Tools\VsDevCmd.bat" -no_ext -winsdk=none %*
@setlocal
@pushd %~dp0
@set _C=Release
@set _P=%~dp0build

msbuild -t:restore -p:Configuration=%_C% || exit /b

msbuild -p:Configuration=%_C% || exit /b

msbuild Src\01\01\Web\KSociety.Com.Pre.Web.App\KSociety.Com.Pre.Web.App.csproj -t:restore -p:Configuration=%_C% || exit /b

msbuild Src\01\01\Web\KSociety.Com.Pre.Web.App\KSociety.Com.Pre.Web.App.csproj -t:Publish -p:Configuration=%_C% -p:SelfContained=false -p:Platform="Any CPU" -p:TargetFramework="net6.0" -p:OutputPath=%_P%\KSociety.Com.Pre.Web.App\%_C%\net6.0\ || exit /b

msbuild Src\01\02\Host\KSociety.Com.Srv.Host\KSociety.Com.Srv.Host.csproj -t:restore -p:Configuration=%_C% || exit /b

msbuild Src\01\02\Host\KSociety.Com.Srv.Host\KSociety.Com.Srv.Host.csproj -t:Publish -p:Configuration=%_C% -p:SelfContained=false -p:Platform="Any CPU" -p:TargetFramework="net6.0" -p:OutputPath=%_P%\KSociety.Com.Srv.Host\%_C%\net6.0\ || exit /b

msbuild Src\00\KSociety.Com.Install\KSociety.Com.Install.csproj -t:restore -p:Configuration=%_C% || exit /b

msbuild Src\00\KSociety.Com.Install\KSociety.Com.Install.csproj -p:Configuration=%_C% -p:TargetFramework="net461" || exit /b

@popd
@endlocal

rem

@setlocal
@pushd %~dp0
@set _C=Release
@set _P=%~dp0build

@if "%VCToolsVersion%"=="" call :StartDeveloperCommandPrompt || exit /b

msbuild -t:restore -p:Configuration=%_C% || exit /b

msbuild -p:Configuration=%_C% || exit /b

msbuild src\01\01\Web\KSociety.Log.Pre.Web.App\KSociety.Log.Pre.Web.App.csproj -t:restore -p:Configuration=%_C% || exit /b

msbuild src\01\01\Web\KSociety.Log.Pre.Web.App\KSociety.Log.Pre.Web.App.csproj -t:Publish -p:Configuration=%_C% -p:DeleteExistingFiles=true -p:TargetFramework="net6.0" -p:OutputPath=%_P%\KSociety.Log.Pre.Web.App\%_C%\net6.0\ || exit /b

msbuild src\01\01\Web\KSociety.Log.Pre.Web.App\KSociety.Log.Pre.Web.App.csproj -t:Publish -p:Configuration=%_C% -p:DeleteExistingFiles=true -p:TargetFramework="net7.0" -p:OutputPath=%_P%\KSociety.Log.Pre.Web.App\%_C%\net7.0\ || exit /b

msbuild src\01\02\Host\KSociety.Log.Srv.Host\KSociety.Log.Srv.Host.csproj -t:restore -p:Configuration=%_C% || exit /b

msbuild src\01\02\Host\KSociety.Log.Srv.Host\KSociety.Log.Srv.Host.csproj -t:Publish -p:Configuration=%_C% -p:DeleteExistingFiles=true -p:TargetFramework="net6.0" -p:OutputPath=%_P%\KSociety.Log.Srv.Host\%_C%\net6.0\ || exit /b

msbuild src\01\02\Host\KSociety.Log.Srv.Host\KSociety.Log.Srv.Host.csproj -t:Publish -p:Configuration=%_C% -p:DeleteExistingFiles=true -p:TargetFramework="net7.0" -p:OutputPath=%_P%\KSociety.Log.Srv.Host\%_C%\net7.0\ || exit /b

msbuild src\00\Log\KSociety.LogServer.MsiSetup\KSociety.LogServer.MsiSetup.wixproj -t:clean;restore -p:Configuration=%_C% -p:NetVersion=net6.0 || exit /b

msbuild src\00\Log\KSociety.LogServer.MsiSetup\KSociety.LogServer.MsiSetup.wixproj -p:Configuration=%_C% -p:NetVersion=net6.0 -p:OutputPath=%_P%\KSociety.LogServer.MsiSetup\%_C%\net6.0\ || exit /b

msbuild src\00\Log\KSociety.LogServer.MsiSetup\KSociety.LogServer.MsiSetup.wixproj -t:clean;restore -p:Configuration=%_C% -p:NetVersion=net7.0 || exit /b

msbuild src\00\Log\KSociety.LogServer.MsiSetup\KSociety.LogServer.MsiSetup.wixproj -p:Configuration=%_C% -p:NetVersion=net7.0 -p:OutputPath=%_P%\KSociety.LogServer.MsiSetup\%_C%\net7.0\ || exit /b

REM

msbuild src\00\Log\KSociety.LogWebApp.MsiSetup\KSociety.LogWebApp.MsiSetup.wixproj -t:clean;restore -p:Configuration=%_C% -p:NetVersion=net6.0 || exit /b

msbuild src\00\Log\KSociety.LogWebApp.MsiSetup\KSociety.LogWebApp.MsiSetup.wixproj -p:Configuration=%_C% -p:NetVersion=net6.0 -p:OutputPath=%_P%\KSociety.LogWebApp.MsiSetup\%_C%\net6.0\ || exit /b

msbuild src\00\Log\KSociety.LogWebApp.MsiSetup\KSociety.LogWebApp.MsiSetup.wixproj -t:clean;restore -p:Configuration=%_C% -p:NetVersion=net7.0 || exit /b

msbuild src\00\Log\KSociety.LogWebApp.MsiSetup\KSociety.LogWebApp.MsiSetup.wixproj -p:Configuration=%_C% -p:NetVersion=net7.0 -p:OutputPath=%_P%\KSociety.LogWebApp.MsiSetup\%_C%\net7.0\ || exit /b

REM

msbuild src\00\Log\KSociety.Log.Install\KSociety.Log.Install.wixproj -t:clean;restore -p:Configuration=%_C% -p:NetVersion=net6.0 || exit /b

msbuild src\00\Log\KSociety.Log.Install\KSociety.Log.Install.wixproj -p:Configuration=%_C% -p:NetVersion=net6.0 -p:OutputPath=%_P%\KSociety.Log.Install\%_C%\net6.0\ || exit /b

msbuild src\00\Log\KSociety.Log.Install\KSociety.Log.Install.wixproj -t:clean;restore -p:Configuration=%_C% -p:NetVersion=net7.0 || exit /b

msbuild src\00\Log\KSociety.Log.Install\KSociety.Log.Install.wixproj -p:Configuration=%_C% -p:NetVersion=net7.0 -p:OutputPath=%_P%\KSociety.Log.Install\%_C%\net7.0\ || exit /b

goto LExit

:StartDeveloperCommandPrompt

echo Initializing developer command prompt

if not exist "%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" (
  "%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"
  exit /b 2
)

for /f "usebackq delims=" %%i in (`"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" -version [17.0^,18.0^) -property installationPath`) do (
  if exist "%%i\Common7\Tools\vsdevcmd.bat" (
    call "%%i\Common7\Tools\vsdevcmd.bat" -no_logo
    exit /b
  )
  echo developer command prompt not found in %%i
)

echo No versions of developer command prompt found
exit /b 2

:LExit
@popd
@endlocal