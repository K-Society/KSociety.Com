@call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat" -no_ext -winsdk=none %*
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