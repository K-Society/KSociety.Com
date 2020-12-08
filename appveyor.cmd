@setlocal
@pushd %~dp0
@set _C=Release
@set _P=%~dp0build

msbuild -t:restore -p:Configuration=%_C% || exit /b

msbuild -p:Configuration=%_C% || exit /b

msbuild Src\01\01\Com\Web\Std.Pre.Com.Web.App\Std.Pre.Com.Web.App.csproj -t:restore -p:Configuration=%_C% || exit /b

msbuild Src\01\01\Com\Web\Std.Pre.Com.Web.App\Std.Pre.Com.Web.App.csproj -t:Publish -p:Configuration=%_C% -p:SelfContained=false -p:Platform="Any CPU" -p:TargetFramework="net5.0" -p:OutputPath=%_P%\Std.Pre.Com.Web.App\%_C%\net5.0\ || exit /b

msbuild Src\01\02\Host\Com\Std.Srv.Host.Com\Std.Srv.Host.Com.csproj -t:restore -p:Configuration=%_C% || exit /b

msbuild Src\01\02\Host\Com\Std.Srv.Host.Com\Std.Srv.Host.Com.csproj -t:Publish -p:Configuration=%_C% -p:SelfContained=false -p:Platform="Any CPU" -p:TargetFramework="net5.0" -p:OutputPath=%_P%\Std.Srv.Host.Com\%_C%\net5.0\ || exit /b

msbuild Src\00\Com\Std.Install.Com\Std.Install.Com.csproj -t:restore -p:Configuration=%_C% || exit /b

msbuild Src\00\Com\Std.Install.Com\Std.Install.Com.csproj -p:Configuration=%_C% -p:TargetFramework="net35" || exit /b

@popd
@endlocal